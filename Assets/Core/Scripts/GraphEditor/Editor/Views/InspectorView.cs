using UnityEngine.UIElements;

namespace hazethedev.StateMachine.Editor
{
    public class InspectorView : VisualElement
    {
        public new class UxmlFactory : UnityEngine.UIElements.UxmlFactory<InspectorView, VisualElement.UxmlTraits> { }
        
        public InspectorView()
        {
            
        }
    }
}