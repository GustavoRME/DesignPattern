using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventQueuePattern
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private TutorialTextCloserEvent _firstEvent = default;
        [SerializeField] private BlinkSomethingEvent _secondEvent = default;

        private TutorialEventQueue _tutorialEventQueue;

        private void Awake()
        {
            _tutorialEventQueue = new TutorialEventQueue();
        }

        private void Start()
        {
            StartFirstEvent();
        }

        private void StartFirstEvent()
        {
            _firstEvent.OnFinished += StartSecondEvent;
            _firstEvent.StartListenning(_tutorialEventQueue, this);
        }

        private void StartSecondEvent()
        {
            _firstEvent.OnFinished -= StartSecondEvent;

            _secondEvent.OnFinished += EndEvents;
            _secondEvent.StartListenning(_tutorialEventQueue);
        }

        private void EndEvents()
        {
            _secondEvent.OnFinished -= EndEvents;
            Debug.Log("All events finish");
        }
    }

}
