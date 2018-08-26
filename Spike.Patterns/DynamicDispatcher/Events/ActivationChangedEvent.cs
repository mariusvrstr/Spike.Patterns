
using Spike.Patterns.DynamicDispatcher.Generic;

namespace Spike.Patterns.DynamicDispatcher.Events
{
    public class ActivationChangedEvent :  User, IEvent
    {
        public bool Active { get; set; }
    }
}
