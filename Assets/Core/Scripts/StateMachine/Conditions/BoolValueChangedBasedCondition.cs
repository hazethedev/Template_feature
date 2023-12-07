using System;

namespace hazethedev.StateMachine
{
    [Serializable]
    public class BoolValueChangedBasedCondition : ValueChangedBasedCondition<bool>
    {
        protected override bool IsMet(in bool value) => Value == value;
    }
}