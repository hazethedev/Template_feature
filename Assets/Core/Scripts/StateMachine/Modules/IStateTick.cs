namespace hazethedev.StateMachine
{
    public interface IStateTick : IStateComponent
    {
        void Tick(in float deltaTime);
    }
}