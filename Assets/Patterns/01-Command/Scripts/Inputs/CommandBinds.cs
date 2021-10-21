using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class CommandBinds : MonoBehaviour
    {
        private static CommandBinds _instance;
        public static CommandBinds Instance
        {
            get => _instance;
            set => _instance = value;
        }

        [Header("WASD")]
        [SerializeField] private Command _buttonW = default;
        [SerializeField] private Command _buttonA = default;
        [SerializeField] private Command _buttonS = default;
        [SerializeField] private Command _buttonD = default;

        [Header("Arrows")]
        [SerializeField] private Command _upArrow = default;
        [SerializeField] private Command _leftArrow = default;
        [SerializeField] private Command _downArrow = default;
        [SerializeField] private Command _rightArrow = default;

        [Space]
        [SerializeField] private Command _buttonSpace = default;

        [Space]
        [SerializeField] private Command _buttonZ = default;

        private Dictionary<KeyCode, Command> _binds;

        private void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            _binds = new Dictionary<KeyCode, Command>()
        {
                {KeyCode.W, _buttonW },
                {KeyCode.A, _buttonA },
                {KeyCode.S, _buttonS },
                {KeyCode.D, _buttonD },
                {KeyCode.UpArrow, _upArrow },
                {KeyCode.LeftArrow, _leftArrow },
                {KeyCode.DownArrow, _downArrow },
                {KeyCode.RightArrow, _rightArrow },
                {KeyCode.Space, _buttonSpace },
                {KeyCode.Z, _buttonZ }
        };
        }

        /// <summary>
        /// Get command from input
        /// </summary>
        /// <returns></returns>
        public Command HandleInput()
        {
            foreach (var keyCode in _binds.Keys)
            {
                if (Input.GetKeyDown(keyCode))
                    return _binds[keyCode];
            }
            return null;
        }

        /// <summary>
        /// Get KeyCode pressed from input
        /// </summary>
        /// <returns></returns>
        public KeyCode HandleKeyCode()
        {
            foreach (var keyCode in _binds.Keys)
            {
                if (Input.GetKeyDown(keyCode))
                    return keyCode;
            }
            return KeyCode.None;
        }

        /// <summary>
        /// Bind the command for the new key, and clear the old key was used
        /// </summary>
        /// <param name="keyCode"></param>
        /// <param name="command"></param>
        public void SetCommandAndClear(KeyCode keyCode, Command command)
        {
            if (!_binds.ContainsKey(keyCode))
                return;

            //Remove the command from the old key
            if (_binds.ContainsValue(command))
            {
                foreach (var kCode in _binds.Keys)
                {
                    if (_binds[kCode] == command)
                    {
                        _binds[kCode] = null;
                        break;
                    }
                }
            }

            //Assign to the new key
            _binds[keyCode] = command;
            UpdateCommandForVariables(keyCode);
        }

        private void UpdateCommandForVariables(KeyCode keyCode)
        {
            //Hard code...
            _buttonW = _binds[KeyCode.W];
            _buttonA = _binds[KeyCode.A];
            _buttonS = _binds[KeyCode.S];
            _buttonD = _binds[KeyCode.D];

            _upArrow = _binds[KeyCode.UpArrow];
            _leftArrow = _binds[KeyCode.LeftArrow];
            _downArrow = _binds[KeyCode.DownArrow];
            _rightArrow = _binds[KeyCode.RightArrow];

            _buttonSpace = _binds[KeyCode.Space];
            _buttonZ = _binds[KeyCode.Z];
        }
    }
}
