using System;
using System.IO;
using System.Linq;
using UnityEngine;

namespace hazethedev.Utilities
{
    public static class PathUtilities
    {
        public static string GetRootPath() => Path.GetDirectoryName(Application.dataPath);

        public static string GetPathOf(Type type, Func<string, bool> verificationCallback)
        {
            var searchPattern = $"*{type.Name}.cs";
            var files = Directory.GetFiles(Application.dataPath, searchPattern, SearchOption.AllDirectories);

            return files.Length == 0 ? null : files.FirstOrDefault(verificationCallback.Invoke);
        }
    }
}