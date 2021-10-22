using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class MoveLeftCommand : Command
    {
        public override void Execute(GameObject go)
        {
            _messageUI.Write($"Moved left {go.name}");
        }

        public override void Undo(GameObject go)
        {
            _messageUI.Write($"Return Move left {go.name}");
        }
    }
}

