using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public abstract class Command : MonoBehaviour
    {
        public virtual void Execute(GameObject go)
        {

        }

        public virtual void Undo(GameObject go)
        {

        }
    
    }
}
