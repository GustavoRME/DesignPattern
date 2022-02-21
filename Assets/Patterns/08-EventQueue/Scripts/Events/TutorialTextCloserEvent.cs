using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace EventQueuePattern
{
    public class TutorialTextCloserEvent : MonoBehaviour, IEvent
    {
        private TutorialEventQueue _tutorialEvent;
        private GameController _gameController;
        
        public UnityEvent _onCloseTutorialScreen;
        
        public UnityAction OnFinished { get; set; }

        public void StartListenning(TutorialEventQueue tutorialEventQueue, GameController gameController)
        {
            _tutorialEvent = tutorialEventQueue;
            _gameController = gameController;
        }

        public void Execute()
        {
            _onCloseTutorialScreen?.Invoke();
            OnFinished?.Invoke();
        }

        public void TriggerEvent()
        {
            _tutorialEvent.Enqueue(this);
        }
    }

}

