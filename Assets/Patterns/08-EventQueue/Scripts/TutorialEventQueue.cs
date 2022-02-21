using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EventQueuePattern
{
    public class TutorialEventQueue
    {
        private readonly Queue<IEvent> _eventQueue;
        private IEvent _currentEvent;
        private bool _isPending;

        public TutorialEventQueue()
        {
            _eventQueue = new Queue<IEvent>();
        }

        public void Enqueue(IEvent e)
        {
            _eventQueue.Enqueue(e);

            if (!_isPending)
                DoNext();
        }

        private void DoNext()
        {
            if (_eventQueue.Count == 0)
                return;

            _isPending = true;

            _currentEvent = _eventQueue.Dequeue();

            _currentEvent.OnFinished += OnEventFinished;
            _currentEvent.Execute();
        }

        private void OnEventFinished()
        {
            _currentEvent.OnFinished -= OnEventFinished;
            _isPending = false;

            if (_eventQueue.Count > 0)
                DoNext();
        }
    }

}
