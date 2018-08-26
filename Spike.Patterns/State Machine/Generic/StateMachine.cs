using System;
using System.Collections.Generic;
using System.Linq;

namespace Spike.Patterns.State_Machine.Generic
{
    public abstract class StateMachine <T>
        where T : struct, IConvertible
    {
        protected T State { get; private set; }
        protected IEnumerable<Transition<T>> Transitions { get; set; }
        protected abstract IEnumerable<Transition<T>> ConfigureAllowedTransitions();

        protected StateMachine(T startingState)
        {
            State = startingState;

            // ReSharper disable once VirtualMemberCallInConstructor
            Transitions = ConfigureAllowedTransitions();
        }

        protected void Transition(T newState)
        {
            var allowAllTransitions = Transitions == null;
            var hasExactTransition = !allowAllTransitions && Transitions.Any(t => t.StartState != null && t.StartState.Value.Equals(State) && t.EndState != null && t.EndState.Value.Equals(newState));

            var allowAllTransitionsFromCurrent = !allowAllTransitions && !hasExactTransition && Transitions.Any(t => t.StartState != null && t.StartState.Value.Equals(State) && t.EndState == null);
            var allowAllTransitionsToNext = !allowAllTransitions && !hasExactTransition && !allowAllTransitionsFromCurrent && Transitions.Any(t => t.EndState != null && t.EndState.Value.Equals(newState) && t.StartState == null);
            
            if (!allowAllTransitions && !hasExactTransition && !allowAllTransitionsFromCurrent && !allowAllTransitionsToNext)
            {
                throw new InvalidOperationException($"Invalid transition attempted. From [{State}] To [{newState}] is NOT currently allowed.");
            }

            State = newState;
        }
    }
}
