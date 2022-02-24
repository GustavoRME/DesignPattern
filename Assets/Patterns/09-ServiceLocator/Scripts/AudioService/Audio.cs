using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocatorPattern
{
    public abstract class Audio
    {
        public virtual void PlaySound(int soundID) { }

        public virtual void StopSound(int soundID) { }

        public virtual void StopAllSounds() { }
    }
}
