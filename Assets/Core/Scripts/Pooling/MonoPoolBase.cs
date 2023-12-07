using UnityEngine;
using UnityEngine.Pool;

namespace hazethedev.Pooling
{
    public abstract class MonoPoolBase<TPooledObject> : ObjectPoolBase<TPooledObject, ObjectPool<TPooledObject>>
        where TPooledObject : MonoBehaviour, IPoolObject
    {
        [field: SerializeField]
        public PoolDefiner PoolDefiner { get; private set; }
        
        protected override ObjectPool<TPooledObject> CreatePool()
        {
            return new ObjectPool<TPooledObject>(
                createFunc     : CreateObject,
                actionOnGet    : OnGet,
                actionOnRelease: OnRelease,
                actionOnDestroy: OnObjectDestroy,
                collectionCheck: PoolDefiner.UseCollectionCheck,
                defaultCapacity: PoolDefiner.DefaultCapacity,
                maxSize        : PoolDefiner.MaxSize);
        }

        protected abstract TPooledObject CreateObject();

        protected virtual void OnGet(TPooledObject obj)
        {
            obj.gameObject.SetActive(true);
        }

        protected virtual void OnRelease(TPooledObject obj)
        {
            obj.gameObject.SetActive(false);
            obj.ResetAll();
        }

        protected virtual void OnObjectDestroy(TPooledObject obj)
        {
            if (Application.isPlaying)
            {
                Destroy(obj.gameObject);
            }
            else
            {
                DestroyImmediate(obj.gameObject);
            }
        }
    }
}