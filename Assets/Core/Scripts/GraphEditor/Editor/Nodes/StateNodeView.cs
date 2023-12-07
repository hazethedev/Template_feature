namespace hazethedev.StateMachine.Editor
{
    using Attributes;
    
    public class StateNodeView : NodeView
    {
        [DropdownMenuActionName]
        public static readonly string MenuActionName = "New State";

        public override NodeView Clone()
        {
            return new StateNodeView();
        }
    }
}