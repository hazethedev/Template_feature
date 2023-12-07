using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace hazethedev.StateMachine.Editor
{
    public abstract class NodeView : Node
    {
        protected const string StateName = "State Name";
        
        public virtual void Init(Vector2 position = default, Vector2 size = default)
        {
            SetPosition(new Rect(position, size));
        }
        
        public virtual void Draw(string withName = StateName)
        {
            var textField = new TextField() { value = withName };
            textField.AddToClassList("sm-node__text-field");
            titleContainer.Insert(0, textField);

            var inputPort = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi, typeof(bool));
            inputPort.portName = string.Empty;
            inputContainer.Add(inputPort);
            
            var outputPort = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Multi, typeof(bool));
            outputPort.portName = string.Empty;
            outputContainer.Add(outputPort);
        }

        public abstract NodeView Clone();
    }
}