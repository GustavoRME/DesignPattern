using UnityEngine;

namespace SandboxPattern
{
    public abstract class SuperPower
    {
        public abstract void Active();

        protected void Move(string direction)
        {
            Debug.Log($"Move to {direction}");
        }

        protected void SpawnParticle(string particle)
        {
            Debug.Log($"Playing particle {particle}");
        }

        protected void PlaySound(string soundId)
        {
            Debug.Log($"Playing sound {soundId}");
        }

    }

}
