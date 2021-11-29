using UnityEngine;

namespace DoubleBufferPattern
{
    public abstract class ACellularAutomata : MonoBehaviour
    {
        [SerializeField] protected int _gridSize = 0;

        protected ADoubleBuffer<float[,]> _doubleBuffer;

        protected virtual void Awake()
        {
            _doubleBuffer = new ADoubleBuffer<float[,]>(
                new float[_gridSize, _gridSize], 
                new float[_gridSize, _gridSize]);
        }

        public virtual void RunAutomata() { }

        public virtual void UpdateCellularAutomata() 
        {
            _doubleBuffer.SwapBuffers();
            Debug.Log($"Current index {_doubleBuffer.Current}");
            DrawAutomata(_doubleBuffer.GetCurrentBuffer());
        }

        protected virtual void DrawAutomata(float[,] data) { }

        protected bool IsGridBorder(int x, int y)
        {
            return x == 0 || x == _gridSize - 1 || y == 0 || y == _gridSize - 1;
        }
    }

}
