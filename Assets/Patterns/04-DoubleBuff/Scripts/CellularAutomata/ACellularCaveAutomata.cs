using UnityEngine;

namespace DoubleBufferPattern
{
    public class ACellularCaveAutomata : ADoubleBuffer<int[,]>
    {
        [SerializeField] protected int _gridSize = 0;

        protected virtual void Awake()
        {
            InitDoubleBuffer(new int[_gridSize, _gridSize], new int[_gridSize, _gridSize]);
        }

        public virtual void StartCave() { }

        public virtual void GenerateCave() { }

        protected virtual void DrawCave(int[,] data) { }

        protected int GetSurroudingWallsCount(int x, int y)
        {
            int wallCount = 0;

            //Pass through eight cell that are surrouding current cell
            for (int cellY = y - 1; cellY <= y + 1; cellY++)
            {
                for (int cellX = x - 1; cellX <= x + 1; cellX++)
                {
                    if (cellX == x && cellY == y)
                        continue;

                    if (GetCurrentBuffer()[cellX, cellY] == 1)
                        wallCount++;
                }
            }

            return wallCount;
        }

        protected bool IsGridBorder(int x, int y)
        {
            return x == 0 || x == _gridSize - 1 || y == 0 || y == _gridSize - 1;
        }
    }

}
