using System;

namespace hazethedev.StateMachine
{
    [Serializable]
    public abstract class StateMachineBase : IStateMachine
    {
        public static readonly ITransition[] EmptyTransitions = Array.Empty<ITransition>();

        private ITransition[] m_AnyTransitions = EmptyTransitions;
        private ITransition[] m_CurrentTransitions = EmptyTransitions;

        private IState m_DefaultState;
        private IState m_CurrentState;

        protected virtual bool CompareEquality(IState state1, IState state2) => state1.Equals(state2);

        #region IStateMachine Implementation

        public bool TryChangeState()
        {
            var transition = ProcessTransition();
            if (transition is null) return false;
            
            ChangeState(transition.To);
            return true;
        }

        public abstract ITransition[] GetTransitions(IState from);

        #endregion

        private void ChangeState(IState state)
        {
            if (CompareEquality(m_CurrentState, state)) return;
            
            SwitchTo(state);
            m_CurrentTransitions = GetTransitions(m_CurrentState) ?? EmptyTransitions;
            m_CurrentState.Enter();
        }

        private void SwitchTo(IState state)
        {
            m_CurrentState?.Exit();
            m_CurrentState = state;
        }

        private ITransition ProcessTransition()
        {
            foreach (var transition in m_AnyTransitions)
                if (transition.ShouldTransition())
                    return transition;
            
            foreach (var transition in m_CurrentTransitions)
                if (transition.ShouldTransition())
                    return transition;

            return default;
        }
    }
}