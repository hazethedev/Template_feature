using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace hazethedev.StateMachine.Editor
{
    using Collections;
    using Extensions;
    
    public class StateMachineGraphView : GraphView
    {
        public new class UxmlFactory : UnityEngine.UIElements.UxmlFactory<StateMachineGraphView, GraphView.UxmlTraits> { }

        private IKvpCollection<Type, (string, NodeView)> m_NodeViewCollection;

        public StateMachineGraphView()
        {
            Insert(0, new GridBackground());
            var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Core/Scripts/GraphEditor/Editor/Resources/Styles/GraphEditorWindow.uss");
            styleSheets.Add(styleSheet);
            
            this.AddManipulators(new ContentDragger(), new SelectionDragger(), new RectangleSelector());
            SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);

            m_NodeViewCollection = new CachedNodeViewProvider();
        }

        public override void BuildContextualMenu(ContextualMenuPopulateEvent evt)
        {
            base.BuildContextualMenu(evt);
            evt.menu.AppendSeparator("nodes/");

            foreach (var (_, (menuActionName, nodeViewInstance)) in m_NodeViewCollection)
            {
                evt.menu.AppendAction(menuActionName,
                    (menuAction) => AddNodeView(nodeViewInstance, menuAction.eventInfo.mousePosition));
            }
        }

        // there might be another way around to implement this. look for uquerystate, uquerybuilder
        public override List<Port> GetCompatiblePorts(Port startPort, NodeAdapter nodeAdapter)
        {
            return ports
                .ToList()
                .Where(IsCompatible)
                .ToList();
            
            bool IsCompatible(Port endPort)
                => !ReferenceEquals(startPort.node, endPort.node) && startPort.direction != endPort.direction;
        }

        private void AddNodeView(NodeView instance, Vector2 position = default, Vector2 size = default)
        {
            var clone = instance.Clone();
            
            clone.Init(position, size);
            clone.Draw();
            AddElement(clone);
        }
    }
}