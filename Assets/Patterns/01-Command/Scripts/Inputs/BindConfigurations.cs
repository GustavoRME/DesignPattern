using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class BindConfigurations : MonoBehaviour
    {
        [SerializeField] private PlayerController _playerController = default;
        
        private ActionConfigurationUI _actionConfig;

        private void Awake()
        {
            enabled = false;
        }

        private void Update()
        {
            //Key pressed and need be assign with the action selected
            KeyCode keyCode = CommandBinds.Instance.HandleKeyCode();
            if (keyCode != KeyCode.None)
            {
                CommandBinds.Instance.SetCommandAndClear(keyCode, _actionConfig._command);

                Debug.Log($"Key pressed {keyCode}");

                _actionConfig.SetKey(keyCode.ToString());
                ListeningKeys(false, null);
            }
        }

        public void ListeningKeys(bool isListening, ActionConfigurationUI action)
        {
            _actionConfig = action;
            enabled = isListening;
            _playerController.CanListeningInputs = isListening;
        }
    }
}


