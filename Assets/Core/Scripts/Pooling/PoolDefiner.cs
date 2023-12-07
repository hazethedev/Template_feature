using UnityEngine;

namespace hazethedev.Pooling
{
    [CreateAssetMenu(fileName = "Pool Definer", menuName = "Common/Pooling/Definer")]
    public class PoolDefiner : ScriptableObject
    {
        [field: SerializeField] public bool UseCollectionCheck { get; private set; }
        [field: SerializeField] public int DefaultCapacity { get; private set; }
        [field: SerializeField] public int MaxSize { get; private set; }
    }
}