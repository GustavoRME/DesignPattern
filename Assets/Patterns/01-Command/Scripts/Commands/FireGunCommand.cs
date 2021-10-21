using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class FireGunCommand : Command
    {
        public override void Execute(GameObject go)
        {
            Debug.Log($"Fired with {go.name}");
        }

        public override void Undo(GameObject go)
        {
            Debug.Log($"Return fire with {go.name}");
        }
    }
}


