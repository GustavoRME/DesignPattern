using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class PlayerController : MonoBehaviour
    {
        private void Update()
        {
            Command command = CommandBinds.Instance.HandleInput();
            if (command != null)
                command.Execute(gameObject);
        }
    }
}
