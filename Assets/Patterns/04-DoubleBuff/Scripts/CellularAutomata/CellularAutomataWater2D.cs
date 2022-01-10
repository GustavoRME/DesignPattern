using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoubleBufferPattern
{
    public class CellularAutomataWater2D : ACellularAutomata
    {
        [Header("Water cell")]
        [Tooltip("Max amount of water that a cell can have")]
        [SerializeField] private float _maxWaterAmountCell = 1.0f;
        [Tooltip("Min amount of water that a cell can have if isn't empty")]
        [SerializeField] private float _minWaterAmountCell = 0.10f;
        [Tooltip("Amount of water can flow to cells that are by side")]
        [SerializeField] private float _waterAmountFlow = 0.25f;

        [Space]
        [SerializeField] private Grid _grid = default; 

        public override void RunAutomata()
        {
            _grid.DrawGrid(_gridSize);

            for (int y = 0; y < _gridSize; y++)
            {
                for (int x = 0; x < _gridSize; x++)
                {
                    if (y == 0)
                    {
                        _doubleBuffer.GetCurrentBuffer()[x, y] = _maxWaterAmountCell;
                    }
                }
            }
            DrawAutomata(_doubleBuffer.GetCurrentBuffer());
        }

        public override void UpdateCellularAutomata()
        {
            float[,] curData = _doubleBuffer.GetCurrentBuffer();        //All the new values will be calculated from this matrix
            float[,] data = _doubleBuffer.GetNextBuffer();              //All the new values will be set in this matrix
            for (int y = 0; y < _gridSize; y++)
            {
                for (int x = 0; x < _gridSize; x++)
                {
                    //it's a wall;
                    if (curData[x, y] < 0.0f)
                        continue;

                    if(y < _gridSize - 1)
                    {
                        //is not a wall
                        if(curData[x, y + 1] >= 0.0f)
                        {
                            //Check if the below cell have less water the current
                            if (curData[x, y + 1] < curData[x, y])
                            {
                                Debug.Log("Cell y + 1 is bellow of cell y and is not a wall");
                                float remaining = _maxWaterAmountCell - curData[x, y + 1];

                                data[x, y + 1] += remaining;
                                curData[x, y] -= remaining;
                            }
                        }
                        else if(curData[x, y] > 0.0f)
                            data[x, y] = curData[x, y];
                        //right
                        else if (x < _gridSize - 1)
                        {
                            if (curData[x + 1, y] < curData[x, y])
                            {
                                float remaining = _waterAmountFlow - curData[x + 1, y];
                                data[x, y + 1] += remaining;
                                curData[x, y] -= remaining;
                            }
                        }
                        //left
                        else if (x > 0)
                        {
                            if (curData[x - 1, y] < curData[x, y])
                            {
                                float remaining = _waterAmountFlow - curData[x - 1, y];
                                data[x, y - 1] += remaining;
                                curData[x, y] -= remaining;
                            }
                        }
                    }
                    
                    
                }
            }

            base.UpdateCellularAutomata();
        }

        public void SetWall(int x, int y, bool isWall)
        {
            Debug.Log($"Setting cell [{x}][{y}] as wall? {isWall}");
            _doubleBuffer.GetCurrentBuffer()[x, y] = isWall ? -1.0f : 0.0f;
            _doubleBuffer.GetNextBuffer()[x, y] = isWall ? -1.0f : 0.0f;
        }

        protected override void DrawAutomata(float[,] data)
        {
            for (int y = 0; y < _gridSize; y++)
            {
                for (int x = 0; x < _gridSize; x++)
                {
                    _grid.SetCell(x, y, data[x, y], data[x, y] > 0.0f);
                }
            }
        }
    }

}
