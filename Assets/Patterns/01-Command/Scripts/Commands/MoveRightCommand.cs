using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class MoveRightCommand : Command
    {
        public override void Execute(GameObject go)
        {
            Debug.Log($"Moved right {go.name}");
        }
    }
}
