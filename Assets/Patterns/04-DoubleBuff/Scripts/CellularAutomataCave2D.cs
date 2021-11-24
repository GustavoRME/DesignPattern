using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoubleBufferPattern
{
    public class CellularAutomataCave2D : ACellularCaveAutomata
    {
        [SerializeField] private MeshRenderer _meshRenderer = default;

        [Tooltip("The higher the fill percentage, the smaller the caves")]
        [SerializeField] [Range(0, 1)] private float _fillPercentage = 0.0f;

        protected override void Awake()
        {
            base.Awake();

            StartCave();
        }

        public override void StartCave()
        {
            for (int y = 0; y < _gridSize; y++)
            {
                for (int x = 0; x < _gridSize; x++)
                {
                    if (IsGridBorder(x, y))
                        GetCurrentBuffer()[x, y] = 1;
                    else
                        GetCurrentBuffer()[x, y] = Random.Range(0f, 1f) < _fillPercentage ? 1 : 0;
                }
            }
        }

        public override void GenerateCave()
        {
            for (int y = 0; y < _gridSize; y++)
            {
                for (int x = 0; x < _gridSize; x++)
                {
                    if (IsGridBorder(x, y))
                    {
                        GetNextBuffer()[x, y] = 1;
                        continue;
                    }

                    int wallCount = GetSurroudingWallsCount(x, y);

                    if (wallCount > 4) GetNextBuffer()[x, y] = 1;
                    else if (wallCount == 4) GetNextBuffer()[x, y] = GetCurrentBuffer()[x, y];
                    else GetNextBuffer()[x, y] = 0;
                }
            }

            SwapBuffers();
            DrawCave(GetCurrentBuffer());
        }

        protected override void DrawCave(int[,] data)
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
                    colors[y * _gridSize + x] = data[x, y] == 1 ? Color.black : Color.white;
                }
            }

            tex2D.SetPixels(colors);
            tex2D.Apply();

            _meshRenderer.sharedMaterial.mainTexture = tex2D;
        }
    }
}
