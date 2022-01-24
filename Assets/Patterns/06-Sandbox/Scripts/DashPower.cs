using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SandboxPattern
{
    public class DashPower : SuperPower
    {
        public override void Active()
        {
            Move("Faster");
            PlaySound("Dash");
            SpawnParticle("Smooth Smoke");
        }
    }
}
