using System;
using UnityEngine.Events;

namespace EventQueuePattern
{
    public interface IEvent
    {
        UnityAction OnFinished { get; set; }
        
        void Execute();
    }

}
