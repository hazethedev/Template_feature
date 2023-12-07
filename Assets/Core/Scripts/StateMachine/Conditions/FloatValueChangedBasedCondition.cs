using System;

namespace hazethedev.StateMachine
{
    [Serializable]
    public class FloatValueChangedBasedCondition : ValueChangedBasedCondition<float>
    {
        public enum FloatComparisonType { LessThan, GreaterThan }

        public FloatComparisonType ComparisonType;

        protected override bool IsMet(in float value)
        {
            return ComparisonType switch
            {
                FloatComparisonType.GreaterThan => Value > value,
                FloatComparisonType.LessThan    => Value < value,
                _ => false,
            };
        }
    }
}