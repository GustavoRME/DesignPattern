using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class MoveForwardCommand : Command
    {
        public override void Execute(GameObject go)
        {
            Debug.Log($"Move forward {go.name}");
        }

        public override void Undo(GameObject go)
        {
            Debug.Log($"Return Move forward {go.name}");
        }
    }
}
