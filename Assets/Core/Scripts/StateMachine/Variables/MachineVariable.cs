using System;

namespace hazethedev.StateMachine.Variables
{
    [Serializable]
    public abstract class MachineVariable<T> : IValueChangedNotifier<T>
        where T : struct, IEquatable<T>, IComparable<T>
    {
        public event Action<T> OnValueChanged;
        public string Id;
        public T Value;

        public void Set(T value)
        {
            if (Value.Equals(value)) return;
            Value = value;
            OnValueChanged?.Invoke(Value);
        }
    }
    
    [Serializable]
    public class BoolVariable : MachineVariable<bool> {}
    [Serializable]
    public class IntVariable : MachineVariable<int> {}
    [Serializable]
    public class FloatVariable : MachineVariable<float> {}
}