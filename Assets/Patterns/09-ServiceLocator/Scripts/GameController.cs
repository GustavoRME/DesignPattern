using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ServiceLocatorPattern
{
    public class GameController : MonoBehaviour
    {
        private Audio _audio;

        private void Awake()
        {
            _audio = new ConsoleAudio();
            Locator.Initialize();
            Locator.Provide(_audio);
        }

        public void ChangeToAudio()
        {
            Locator.Provide(_audio);
        }

        public void ChangeToLogAudio()
        {
            LoggedAudio loggedAudio = new LoggedAudio(Locator.GetAudio());
            Locator.Provide(loggedAudio);
        }
    }
}
