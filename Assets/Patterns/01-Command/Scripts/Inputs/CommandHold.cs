using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommandPattern
{
    public class CommandHold : MonoBehaviour
    {
        [SerializeField] private Command _command = default;

        public Command Command => _command;
    }
}
