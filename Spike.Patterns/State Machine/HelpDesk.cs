using System.Collections.Generic;
using Spike.Patterns.State_Machine.Generic;

namespace Spike.Patterns.State_Machine
{
    public enum HelpDeskState
    {
        Undefined = 0,
        Logged = 1,
        Acknowledge = 2,
        Closed = 3,
        Resolved = 4,
        ReOpened = 5
    }

    public sealed class HelpDesk : StateMachine<HelpDeskState>
    {
        public HelpDesk() 
            : base(HelpDeskState.Logged) {}

        public HelpDeskState GetCurrentState => State;

        public void AcknowledgeTicket()
        {
            // Do acknowledgment
            Transition(HelpDeskState.Acknowledge);
        }

        public void CloseTicket()
        {
            // Close Ticket
            Transition(HelpDeskState.Closed);
        }

        public void ResolveTicket()
        {
            // Resolve Ticket
            Transition(HelpDeskState.Resolved);
        }

        public void ReopenTicket()
        {
            // Do re-opening
            Transition(HelpDeskState.ReOpened);
        }

        protected override IEnumerable<Transition<HelpDeskState>> ConfigureAllowedTransitions()
        {
            return new List<Transition<HelpDeskState>>
            {
                Transition<HelpDeskState>.Create(HelpDeskState.Logged, HelpDeskState.Acknowledge),
                Transition<HelpDeskState>.Create(HelpDeskState.Acknowledge, HelpDeskState.Resolved),
                Transition<HelpDeskState>.Create(HelpDeskState.Resolved, HelpDeskState.ReOpened),
                Transition<HelpDeskState>.Create(HelpDeskState.Closed, HelpDeskState.ReOpened),
                Transition<HelpDeskState>.CreateFromAnyState(HelpDeskState.Closed),
            };
        }
    }
}
