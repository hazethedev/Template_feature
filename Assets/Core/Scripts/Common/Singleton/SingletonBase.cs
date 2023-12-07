using UnityEngine;

namespace hazethedev.Common
{
    public abstract class SingletonBase<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T s_Instance;

        public static T Instance
        {
            get
            {
                if (s_Instance == null)
                {
                    s_Instance = FindObjectOfType<T>();
                    if (s_Instance != null) return s_Instance;
                    
                    var singletonObj = new GameObject(name: typeof(T).ToString());
                    s_Instance = singletonObj.AddComponent<T>();
                }
                return s_Instance;
            }
        }

        protected virtual void Awake()
        {
            if (s_Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            s_Instance = GetComponent<T>();

            if (s_Instance == null)
                return;
        }
    }
}