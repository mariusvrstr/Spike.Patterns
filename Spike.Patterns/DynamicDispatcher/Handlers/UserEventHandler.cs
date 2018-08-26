using System;
using Spike.Patterns.DynamicDispatcher.Events;

namespace Spike.Patterns.DynamicDispatcher.Handlers
{
    public class UserEventHandler
    {
        public void Handle(ActivationChangedEvent @event)
        {
            Console.WriteLine($"Name [{@event.Name}] Surname [{@event.Surname}] Activation Status [{@event.Active}]");
        }

        public void Handle(RoleChangedEvent @event)
        {
            Console.WriteLine($"Name [{@event.Name}] Surname [{@event.Surname}] Roles Associated [{string.Join(", ", @event.Roles)}]");
        }
    }
}
