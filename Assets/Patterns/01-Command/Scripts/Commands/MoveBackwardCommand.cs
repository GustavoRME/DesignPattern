using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class MoveBackwardCommand : Command
    {
        public override void Execute(GameObject go)
        {
            _messageUI.Write($"Moved backward {go.name}");
        }

        public override void Undo(GameObject go)
        {
            _messageUI.Write($"Return move backward {go.name}");
        }
    }
}
