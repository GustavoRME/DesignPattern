using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocatorPattern 
{ 
    public class LoggedAudio : Audio
    {
        private readonly Audio _wrapped;

        public LoggedAudio(Audio wrapped)
        {
            _wrapped = wrapped;
        }

        public override void PlaySound(int soundID)
        {
            LogMessage($"Playing sound {soundID}");
            _wrapped.PlaySound(soundID);
        }

        public override void StopSound(int soundID)
        {
            LogMessage($"Sound {soundID} stopped");
            _wrapped.StopSound(soundID);
        }

        public override void StopAllSounds()
        {
            LogMessage($"All sound has stopped");
            _wrapped.StopAllSounds();
        }

        private void LogMessage(string message)
        {
            Debug.Log($"[LOG] -> {message}");
        }
    }
}

