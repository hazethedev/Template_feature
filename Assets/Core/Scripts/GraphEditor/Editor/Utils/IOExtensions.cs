using System;
using System.IO;

namespace hazethedev.StateMachine.Editor.Extensions
{
    public static class IOExtensions
    {
        public static string ToAssetPath(this FileInfo fileInfo)
        {
            ReadOnlySpan<char> lookup = stackalloc char[] { 'A', 's', 's', 'e', 't', 's' };

            var pathSpan = fileInfo.DirectoryName.AsSpan();
            pathSpan = pathSpan[pathSpan.IndexOf(lookup)..];

            return pathSpan.ToString();
        }
    }
}