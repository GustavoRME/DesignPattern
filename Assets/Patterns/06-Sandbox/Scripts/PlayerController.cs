using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SandboxPattern
{
    public class PlayerController : MonoBehaviour
    {
        private SuperPower _flyPower = default;
        private SuperPower _dashPower = default;

        private void Start()
        {
            _flyPower = new FlyPower();
            _dashPower = new DashPower();

            _flyPower.Active();
            _dashPower.Active();
        }
    }

}
