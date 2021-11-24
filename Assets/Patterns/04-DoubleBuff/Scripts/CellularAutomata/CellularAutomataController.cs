using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DoubleBufferPattern
{
    public class CellularAutomataController : MonoBehaviour
    {
        [SerializeField] private ACellularCaveAutomata _caveGenerate = default;
        [SerializeField] private float _stepsTime = 1.0f;

        private bool _isStart;
        private float _time;

        public void StartDrawingCave()
        {
            if (_caveGenerate == null)
                return;

            _time = Time.time;
            _isStart = true;

            _caveGenerate.StartCave();
            _caveGenerate.GenerateCave();
        }

        private void Update()
        {
            if (_caveGenerate == null || !_isStart)
                return;

            if(Time.time - _time > _stepsTime)
            {
                _caveGenerate.GenerateCave();
                _time = Time.time;
            }
        }
    }

}
