using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace hazethedev.StateMachine.Editor.Extensions
{
    public static class VisualElementExtensions
    {
        public static void LoadStyleSheetsAt(this VisualElement element, string path)
        {
            if (path == string.Empty)
            {
                Debug.LogWarning($"path is empty: {path}");
                return;
            }
            
            var guids = AssetDatabase.FindAssets(
                filter: $"t: {typeof(StyleSheet)}",
                searchInFolders: new[] { path });

            if (guids.Length == 0)
            {
                Debug.LogWarning($"No StyleSheet asset found at: {path}");
                return;
            }
            
            foreach (var guid in guids)
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>(assetPath);
                element.styleSheets.Add(styleSheet);
            }
        }
        
        public static void AddManipulators(this VisualElement element, params IManipulator[] manipulators)
        {
            foreach (var manipulator in manipulators)
            {
                element.AddManipulator(manipulator);
            }
        }
    }
}