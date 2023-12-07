using UnityEngine;
using UnityEngine.Pool;

namespace hazethedev.Pooling
{
    public abstract class ObjectPoolBase<TPooledObject, TPool> : MonoBehaviour
        where TPooledObject : class
        where TPool         : IObjectPool<TPooledObject>
    {
        protected TPool m_Pool;

        protected virtual void Awake()
        {
            m_Pool = CreatePool();
        }

        protected abstract TPool CreatePool();
        public TPooledObject Get() => m_Pool.Get();
        public void Release(TPooledObject obj) => m_Pool.Release(obj);
    }
}