using System;

namespace Spike.Patterns.State_Machine.Generic
{
    public class Transition <T>
     where T : struct, IConvertible
    {
        public T? StartState { get; set; }
        public T? EndState { get; set; }

        public static Transition<T> Create(T? startState, T? endState)
        {
            return new Transition<T>()
            {
                StartState = startState,
                EndState = endState
            };
        }

        public static Transition<T> CreateFromAnyState(T endState)
        {
            return Create(null, endState);
        }

        public static Transition<T> CreateToAnyState(T startState)
        {
            return Create(startState, null);
        }
    }
}
