using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoubleBufferPattern
{
    public class CellularAutomataCave2D : ACellularAutomata
    {
        [SerializeField] private MeshRenderer _meshRenderer = default;

        [Tooltip("The higher the fill percentage, the smaller the caves")]
        [SerializeField] [Range(0, 1)] private float _fillPercentage = 0.0f;

        public override void RunAutomata()
        {
            for (int y = 0; y < _gridSize; y++)
            {
                for (int x = 0; x < _gridSize; x++)
                {
                    if (IsGridBorder(x, y))
                        _doubleBuffer.GetCurrentBuffer()[x, y] = 1;
                    else
                        _doubleBuffer.GetCurrentBuffer()[x, y] = Random.Range(0f, 1f) < _fillPercentage ? 1 : 0;
                }
            }
        }

        public override void UpdateCellularAutomata()
        {
            for (int y = 0; y < _gridSize; y++)
            {
                for (int x = 0; x < _gridSize; x++)
                {
                    if (IsGridBorder(x, y))
                    {
                        _doubleBuffer.GetNextBuffer()[x, y] = 1;
                        continue;
                    }

                    int wallCount = GetSurroudingWallsCount(x, y);

                    if (wallCount > 4) _doubleBuffer.GetNextBuffer()[x, y] = 1;
                    else if (wallCount == 4) _doubleBuffer.GetNextBuffer()[x, y] = _doubleBuffer.GetCurrentBuffer()[x, y];
                    else _doubleBuffer.GetNextBuffer()[x, y] = 0;
                }
            }

            base.UpdateCellularAutomata();
        }

        protected override void DrawAutomata(float[,] data)
        {
            Resources.UnloadUnusedAssets();

            Texture2D tex2D = new Texture2D(_gridSize, _gridSize)
            {
                filterMode = FilterMode.Point
            };

            Color[] colors = new Color[_gridSize * _gridSize];
            for (int y = 0; y < _gridSize; y++)
            {
                for (int x = 0; x < _gridSize; x++)
                {
                    //Wall will be painted as black and ground will be white color
                    colors[y * _gridSize + x] = data[x, y] == 1.0f ? Color.black : Color.white;
                }
            }

            tex2D.SetPixels(colors);
            tex2D.Apply();

            _meshRenderer.sharedMaterial.mainTexture = tex2D;
        }

        private int GetSurroudingWallsCount(int x, int y)
        {
            int wallCount = 0;

            //Pass through eight cell that are surrouding current cell
            for (int cellY = y - 1; cellY <= y + 1; cellY++)
            {
                for (int cellX = x - 1; cellX <= x + 1; cellX++)
                {
                    if (cellX == x && cellY == y)
                        continue;

                    if (_doubleBuffer.GetCurrentBuffer()[cellX, cellY] == 1)
                        wallCount++;
                }
            }

            return wallCount;
        }
    }
}
