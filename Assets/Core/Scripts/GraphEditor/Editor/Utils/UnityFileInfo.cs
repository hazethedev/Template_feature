using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

namespace hazethedev.StateMachine.Editor
{
    using Extensions;
    
    public class UnityFileInfo
    {
        public readonly FileInfo FileInfo;
        public readonly string AssetPath;

        private const char Backslash = '\\';
        private StringBuilder m_Builder;

        public UnityFileInfo(Object asset)
        {
            var path = AssetDatabase.GetAssetPath(asset);

            if (string.IsNullOrEmpty(path))
                throw new FileNotFoundException($"Asset not found: {asset}\n");

            FileInfo = new FileInfo(path);
            AssetPath = FileInfo.ToAssetPath();
            m_Builder = new StringBuilder();
            Clear();
        }

        public UnityFileInfo Append(string value)
        {
            m_Builder.Append(Backslash).Append(value);
            return this;
        }

        public override string ToString() => m_Builder.ToString();

        public void Clear()
        {
            m_Builder.Clear();
            m_Builder.Append(AssetPath);
        }
    }
}