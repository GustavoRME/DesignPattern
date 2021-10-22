using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class FireGunCommand : Command
    {
        public override void Execute(GameObject go)
        {
            _messageUI.Write($"Fired with {go.name}");
        }

        public override void Undo(GameObject go)
        {
            _messageUI.Write($"Return fire with {go.name}");
        }
    }
}


