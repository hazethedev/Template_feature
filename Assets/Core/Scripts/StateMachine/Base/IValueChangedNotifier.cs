using System;

namespace hazethedev.StateMachine
{
    public interface IValueChangedNotifier<out T>
    {
        event Action<T> OnValueChanged;
    }
}