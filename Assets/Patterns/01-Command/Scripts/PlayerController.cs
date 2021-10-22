using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class PlayerController : MonoBehaviour
    {
        private UndoCommand _undoCommand;

        public bool CanListeningInputs = true;

        private void Awake()
        {
            _undoCommand = GetComponent<UndoCommand>();
        }

        private void Update()
        {
            Command command = CommandBinds.Instance.HandleInput();
            if (command != null)
            {
                if(_undoCommand)
                    _undoCommand.AddCommand(command);
                command.Execute(gameObject);
            }
        }
    }
}
