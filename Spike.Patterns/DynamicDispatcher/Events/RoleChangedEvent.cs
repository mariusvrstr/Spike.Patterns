using System.Collections.Generic;
using Spike.Patterns.DynamicDispatcher.Generic;

namespace Spike.Patterns.DynamicDispatcher.Events
{
    public class RoleChangedEvent : User, IEvent
    {
        public IEnumerable<string> Roles { get; set; }
    }
}
