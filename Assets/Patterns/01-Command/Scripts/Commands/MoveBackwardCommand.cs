using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackwardCommand : Command
{
    public override void Execute(GameObject go)
    {
        Debug.Log($"Moved backward {go.name}");
    }
}
