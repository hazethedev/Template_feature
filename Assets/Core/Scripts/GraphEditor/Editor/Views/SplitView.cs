using UnityEngine.UIElements;

namespace hazethedev.StateMachine.Editor
{
    public class SplitView : TwoPaneSplitView
    {
        public new class UxmlFactory : UnityEngine.UIElements.UxmlFactory<SplitView, TwoPaneSplitView.UxmlTraits> { }

        public SplitView()
        {
            
        }
    }
}