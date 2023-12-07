using System.Text;
using UnityEngine;
using UnityEngine.Pool;

namespace hazethedev.Pooling
{
    public abstract class ComponentPoolBase<TComponent> : ObjectPoolBase<TComponent, ObjectPool<TComponent>>
        where TComponent : Component
    {
        [field: SerializeField] public PoolDefiner PoolDefiner { get; private set; }

        private int m_NextId;
        private string m_ComponentName;
        private StringBuilder m_StringBuilder;
        
        protected override ObjectPool<TComponent> CreatePool()
        {
            m_StringBuilder = new StringBuilder();
            m_ComponentName = typeof(TComponent).ToString();
            
            return new ObjectPool<TComponent>(
                createFunc     : CreateObject,
                actionOnGet    : OnGet,
                actionOnRelease: OnRelease,
                actionOnDestroy: OnObjectDestroy,
                collectionCheck: PoolDefiner.UseCollectionCheck,
                defaultCapacity: PoolDefiner.DefaultCapacity,
                maxSize        : PoolDefiner.MaxSize);
        }

        protected virtual TComponent CreateObject()
        {
            var objectName = m_StringBuilder
                .Append(m_ComponentName)
                .Append(m_NextId++)
                .ToString();

            m_StringBuilder.Clear();
            
            return new GameObject(objectName)
                .AddComponent<TComponent>();
        }

        protected virtual void OnGet(TComponent component)
        {
            component.gameObject.SetActive(true);
        }

        protected virtual void OnRelease(TComponent component)
        {
            component.gameObject.SetActive(false);
        }

        protected virtual void OnObjectDestroy(TComponent component)
        {
            if (Application.isPlaying)
            {
                Destroy(component.gameObject);
            }
            else
            {
                DestroyImmediate(component.gameObject);
            }
        }
    }
}