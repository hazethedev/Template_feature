using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace hazethedev.StateMachine.Editor
{
    using Extensions;
    
    public class GraphEditorWindow : EditorWindow
    {
        [SerializeField] private VisualTreeAsset m_VisualTreeAsset = default;

        private UnityFileInfo m_FileInfo;

        private StateMachineGraphView m_GraphView;
        private InspectorView m_InspectorView;

        [MenuItem("StateMachine/GraphEditorWindow")]
        private static void OpenWindow()
        {
            var window = GetWindow<GraphEditorWindow>();
            window.titleContent = new GUIContent("GraphEditorWindow");
        }

        private void Awake()
        {
            m_FileInfo = new UnityFileInfo(asset: MonoScript.FromScriptableObject(this));

            var root = rootVisualElement;
            m_GraphView = root.Q<StateMachineGraphView>();
            m_InspectorView = root.Q<InspectorView>();
        }

        private void CreateGUI()
        {
            var root = rootVisualElement;
            m_VisualTreeAsset.CloneTree(root);

            var stylesFolderPath = m_FileInfo.Append("Resources").Append("Styles").ToString();
            root.LoadStyleSheetsAt(stylesFolderPath);
            m_FileInfo.Clear();
        }

        private void OnSelectionChange()
        {
            var context = GetContext();
            if (context == null) return;
            // TODO: populate the view with context.
        }

        private static IGraphContext GetContext()
        {
            if (Selection.activeObject is IGraphContext context)
            {
                return context;
            }

            if (Selection.activeGameObject &&
                Selection.activeGameObject.TryGetComponent(out context))
            {
                return context;
            }

            return null;
        }
    }
}
