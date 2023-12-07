
using System;

namespace hazethedev.StateMachine
{
    public interface IState : IEquatable<IState>
    {
        void Enter();
        void Exit();
    }
}