using System.Collections.Generic;

namespace hazethedev.StateMachine.Collections
{
    public interface IKvpCollection<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        TValue Get(TKey key);
    }
}