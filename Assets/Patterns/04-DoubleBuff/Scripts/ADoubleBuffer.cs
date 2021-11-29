namespace DoubleBufferPattern
{
    public class ADoubleBuffer<T>
    {
        protected int _current;
        protected T[] _pointer;

        public int Current => _current;

        public ADoubleBuffer(T buffer1, T buffer2)
        {
            _pointer = new T[2]
            {
                buffer1,
                buffer2
            };
        }
        
        public T GetCurrentBuffer()
        {
            return _pointer[_current];
        }

        public T GetNextBuffer()
        {
            return _pointer[Next()];
        }

        public void SwapBuffers()
        {
            _current = Next();
        }

        private int Next()
        {
            return 1 - _current;
        }
    }
}