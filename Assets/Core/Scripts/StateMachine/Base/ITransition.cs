namespace hazethedev.StateMachine
{
    public interface ITransition
    {
        IState To { get; }
        bool ShouldTransition();
    }
}