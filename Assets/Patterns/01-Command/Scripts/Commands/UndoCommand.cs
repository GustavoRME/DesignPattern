using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CommandPattern
{
    public class UndoCommand : Command
    {
        private List<Command> _commands = new List<Command>();

        public override void Execute(GameObject go)
        {
            Undo(go);                            
        }

        public override void Undo(GameObject go)
        {
            if (_commands.Count == 0)
            {
                _messageUI.Write("NO MORE COMMAND TO UNDO...");
                return;
            }

            _messageUI.Write("Undo command...");
            Command command = _commands[_commands.Count - 1];
            command.Undo(gameObject);
            _commands.Remove(command);
        }

        public void AddCommand(Command command)
        {
            if (command == this)
                return;

            _messageUI.Write("Command added...");
            _commands.Add(command);
        }
    }
}
