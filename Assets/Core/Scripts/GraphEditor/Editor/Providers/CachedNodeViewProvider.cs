using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;

namespace hazethedev.StateMachine.Editor
{
    using Collections;
    using Attributes;
    
    public class CachedNodeViewProvider : IKvpCollection<Type, (string actionName, NodeView nodeView)>
    {
        private readonly Dictionary<Type, (string actionName, NodeView nodeViewInstance)> m_Cache;

        public CachedNodeViewProvider()
        {
            m_Cache = new();
            InitCache();
        }

        private void InitCache()
        {
            var types = TypeCache.GetTypesDerivedFrom<NodeView>();
            foreach (var type in types)
            {
                var actionName = GetMenuActionNameFor(type);
                var nodeInstance = CreateInstanceFrom(type);

                m_Cache[type] = (actionName, nodeInstance);
            }
        }

        private static NodeView CreateInstanceFrom(Type type)
        {
            var instance = Activator.CreateInstance(type) as NodeView;
            return instance;
        }
        
        private static string GetMenuActionNameFor(Type type)
        {
            var actionName = type.Name;

            var fields = type.GetFields(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var field in fields)
            {
                if (field.GetCustomAttribute<DropdownMenuActionNameAttribute>() == null) continue;
                actionName = field.GetValue(null) as string;
                break;
            }

            return actionName;
        }
        
        public (string, NodeView) Get(Type type)
        {
            if (!m_Cache.TryGetValue(type, out var tuple)) return default;
            
            return tuple;
        }

        public IEnumerator<KeyValuePair<Type, (string actionName, NodeView nodeView)>> GetEnumerator()
        {
            foreach (var (type, (actionName, nodeView)) in m_Cache)
            {
                yield return new KeyValuePair<Type, (string actionName, NodeView nodeView)>(type, (actionName, nodeView));
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}