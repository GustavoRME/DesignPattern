using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocatorPattern
{
    public class Locator
    {
        private static Audio _audioService;
        private readonly static Audio _nullAudioService = new NullAudio();

        public static void Initialize()
        {
            _audioService = _nullAudioService;
        }

        public static void Provide(Audio audio)
        {
            if(audio == null)
            {
                _audioService = _nullAudioService;
            }
            else
            {
                _audioService = audio;
            }
        }
        
        public static Audio GetAudio()
        {
            return _audioService;
        }
    }
}
