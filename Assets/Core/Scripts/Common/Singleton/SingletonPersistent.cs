using UnityEngine;

namespace hazethedev.Common
{
    public class SingletonPersistent<T> : SingletonBase<T> where T : MonoBehaviour
    {
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }
    }
}