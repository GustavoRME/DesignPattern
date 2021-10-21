using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class MoveLeftCommand : Command
    {
        public override void Execute(GameObject go)
        {
            Debug.Log($"Moved left {go.name}");
        }
    }
}

