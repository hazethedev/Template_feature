namespace hazethedev.StateMachine
{
    public interface IStateMachine
    {
        bool TryChangeState();
        ITransition[] GetTransitions(IState from);
    }
}