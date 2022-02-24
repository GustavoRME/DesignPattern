using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocatorPattern
{
    public class ConsoleAudio : Audio
    {
        public override void PlaySound(int soundID)
        {
            Debug.Log($"Playing sound {soundID}");
        }

        public override void StopSound(int soundID)
        {
            Debug.Log($"Stop sound {soundID}");
        }

        public override void StopAllSounds()
        {
            Debug.Log("Stopped all sounds");
        }
    }

}
