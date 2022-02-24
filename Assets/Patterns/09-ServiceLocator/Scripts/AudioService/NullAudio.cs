using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocatorPattern
{
    public class NullAudio : Audio
    {
        public override void PlaySound(int soundID)
        {
            NullReferenceLog();
        }

        public override void StopSound(int soundID)
        {
            NullReferenceLog();
        }

        public override void StopAllSounds()
        {
            NullReferenceLog();
        }

        private void NullReferenceLog()
        {
            Debug.Log("Null audio reference is being used");
        }
    }

}
