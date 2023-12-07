using System;

namespace hazethedev.StateMachine
{
    [Serializable]
    public abstract class ValueChangedBasedCondition<T> : ICondition
        where T : struct, IEquatable<T>, IComparable<T>
    {
        public T Value;
        
        private IValueChangedNotifier<T> m_Notifier;
        private bool m_IsMet;

        protected abstract bool IsMet(in T value);

        public void RegisterListener() => m_Notifier.OnValueChanged += OnValueChanged;
        public void UnregisterListener() => m_Notifier.OnValueChanged -= OnValueChanged;

        private void OnValueChanged(T value) => m_IsMet = IsMet(in value);

        bool ICondition.IsMet() => m_IsMet;
    }
}