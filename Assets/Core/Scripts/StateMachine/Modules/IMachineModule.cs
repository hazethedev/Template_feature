namespace hazethedev.StateMachine
{
    public interface IMachineModule<in TComponent> where TComponent : IStateComponent
    {
        void OnEnter(TComponent stateComponent);
        void OnExit(TComponent stateComponent);
    }
}