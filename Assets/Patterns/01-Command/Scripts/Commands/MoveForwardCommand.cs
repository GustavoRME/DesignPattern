using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class MoveForwardCommand : Command
    {
        public override void Execute(GameObject go)
        {
            _messageUI.Write($"Move forward {go.name}");
        }

        public override void Undo(GameObject go)
        {
            _messageUI.Write($"Return Move forward {go.name}");
        }
    }
}
