using UnityEngine;

namespace DoubleBufferPattern
{
    public class CellularAutomataController : MonoBehaviour
    {
        [SerializeField] private ACellularAutomata _caveGenerate = default;
        [SerializeField] private float _stepsTime = 1.0f;

        private bool _isStart;
        private float _time;

        public void StartDrawingCave()
        {
            if (_caveGenerate == null)
                return;

            _time = Time.time;
            _isStart = true;

            _caveGenerate.RunAutomata();
        }

        private void Update()
        {
            if (_caveGenerate == null || !_isStart)
                return;

            if(Time.time - _time > _stepsTime)
            {
                _caveGenerate.UpdateCellularAutomata();
                _time = Time.time;
            }
        }
    }

}
