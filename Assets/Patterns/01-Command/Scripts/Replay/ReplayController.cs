using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class ReplayController : MonoBehaviour
    {
        [SerializeField] private float _speed = 1.0f;

        private List<Command> _commands = new List<Command>();
        private bool _isPlaying;
        
        private int _currentCommand;
        private float _time;

        private void Update()
        {
            //Commands 
            Command command = CommandBinds.Instance.HandleInput();
            if(command != null)
            {
                if (_isPlaying) 
                    Stop();

                command.Execute(gameObject);
                _commands.Add(command);
            }

            //Replay
            if(_isPlaying && Time.time - _time > (1 / _speed))
            {
                if(_currentCommand < _commands.Count && _currentCommand >= 0)
                {
                    _commands[_currentCommand].Execute(gameObject);
                    _currentCommand++;
                }
                _time = Time.time;
            }

            if(_currentCommand >= _commands.Count)
            {
                _currentCommand = 0;
                _isPlaying = false;
            }
        }

        public void Play()
        {
            if (_commands.Count == 0)
                return;

            Debug.Log("Play...");
            _isPlaying = true;
        }

        public void Stop()
        {
            if (!_isPlaying)
                return;

            Debug.Log("Stop...");
            _isPlaying = false;
        }

        public void Next()
        {
            if (_commands.Count == 0)
                return;

            _currentCommand++;
            _time -= 1;
            Debug.Log("Next...");
        }

        public void Back()
        {
            if (_commands.Count == 0)
                return;

            _currentCommand--;
            _time -= 1;
            Debug.Log("Back...");
        }
    }
}
