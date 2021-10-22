using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class JumpCommand : Command
    {
        public override void Execute(GameObject go)
        {
            _messageUI.Write($"Jumped with {go.name}");
        }

        public override void Undo(GameObject go)
        {
            _messageUI.Write($"Return Jump {go.name}");
        }
    }
}
