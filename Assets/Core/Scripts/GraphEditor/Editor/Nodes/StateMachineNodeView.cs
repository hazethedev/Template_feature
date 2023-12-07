namespace hazethedev.StateMachine.Editor
{
    using Attributes;
    
    public class StateMachineNodeView : NodeView
    {
        [DropdownMenuActionName]
        public static readonly string MenuActionName = "New State Machine";

        public override NodeView Clone()
        {
            return new StateMachineNodeView();
        }
    }
}