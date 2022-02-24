using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ServiceLocatorPattern
{
    public class SoundPlayer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _messageText = default;

        public void PlaySound()
        {
            Locator.GetAudio().PlaySound(100);
            _messageText.text = "Playing sound 100";
        }

        public void StopSound()
        {
            Locator.GetAudio().StopSound(100);
            _messageText.text = "Stopping sound 100";
        }
    }

}
