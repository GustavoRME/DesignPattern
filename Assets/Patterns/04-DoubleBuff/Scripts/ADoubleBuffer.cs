using UnityEngine;

namespace DoubleBufferPattern
{
    public abstract class ADoubleBuffer<T> : MonoBehaviour
    {
        protected int _current;
        protected T[] _pointer;

        //It's should be initialize Double Buffer
        protected void InitDoubleBuffer(T buffer1, T buffer2)
        {
            _pointer = new T[2]
            {
                buffer1,
                buffer2
            };
        }

        protected T GetCurrentBuffer()
        {
            return _pointer[_current];
        }

        protected T GetNextBuffer()
        {
            return _pointer[Next()];
        }

        protected void SwapBuffers()
        {
            _current = Next();
        }

        private int Next()
        {
            return 1 - _current;
        }
    }
}