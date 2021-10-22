using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class MoveRightCommand : Command
    {
        public override void Execute(GameObject go)
        {
            _messageUI.Write($"Moved right {go.name}");
        }

        public override void Undo(GameObject go)
        {
            _messageUI.Write($"Return Move right");
        }
    }
}
