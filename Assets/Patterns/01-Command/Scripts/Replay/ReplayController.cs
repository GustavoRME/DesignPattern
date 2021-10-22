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

        private Coroutine _playCoroutine;

        private void Update()
        {
            Command command = CommandBinds.Instance.HandleInput();
            if(command != null)
            {
                if (_isPlaying) 
                    Stop();

                command.Execute(gameObject);
                _commands.Add(command);
            }    
        }

        public void Play()
        {
            if (_commands.Count == 0)
                return;

            if (_playCoroutine != null)
                StopCoroutine(_playCoroutine);

            Debug.Log("Play...");
            _playCoroutine = StartCoroutine(PlaySequence());
            _isPlaying = true;
        }

        public void Stop()
        {
            if (_playCoroutine == null)
                return;

            Debug.Log("Stop...");
            StopCoroutine(_playCoroutine);
            _isPlaying = false;
        }

        public void Next()
        {
            if (_commands.Count == 0)
                return;

            Debug.Log("Next...");
        }

        public void Back()
        {
            if (_commands.Count == 0)
                return;

            Debug.Log("Back...");
        }

        private IEnumerator PlaySequence()
        {
            while (_currentCommand < _commands.Count)
            {
                _commands[_currentCommand].Execute(gameObject);
                _currentCommand++;
                yield return new WaitForSeconds(_speed);
            }
            _isPlaying = false;
            _currentCommand = 0;
        }
    }
}
