using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class JumpCommand : Command
    {
        public override void Execute(GameObject go)
        {
            Debug.Log($"Jumped with {go.name}");
        }

        public override void Undo(GameObject go)
        {
            Debug.Log($"Return Jump {go.name}");
        }
    }
}
