using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EventQueuePattern
{
    public class BlinkSomethingEvent : MonoBehaviour, IEvent
    {
        [SerializeField] private GameObject _blinker = default;
        
        [Space]
        [SerializeField] private float _interval = .2f;
        [SerializeField] private int _blinkCount = 4;

        private int _currentCount;

        private TutorialEventQueue _tutorialEvent;

        public UnityAction OnFinished { get; set; }

        public void StartListenning(TutorialEventQueue tutorialEventQueue)
        {
            _tutorialEvent = tutorialEventQueue;
        }

        public void TriggerEvent()
        {
            _tutorialEvent.Enqueue(this);
        }

        public void Execute()
        {
            StartCoroutine(Blink());
        }

        private IEnumerator Blink()
        {
            while (_currentCount < _blinkCount)
            {
                _blinker.SetActive(false);
                yield return new WaitForSeconds(_interval);
                _blinker.SetActive(true);
                yield return new WaitForSeconds(_interval);
                _currentCount++;
            }

            OnFinished?.Invoke();
        }
    }

}
