using System;

namespace hazethedev.StateMachine
{
    [Serializable]
    public class IntValueChangedBasedCondition : ValueChangedBasedCondition<int>
    {
        public enum IntComparisonType { Equal, NotEqual, LessThan, GreaterThan }

        public IntComparisonType ComparisonType;

        protected override bool IsMet(in int value)
        {
            return ComparisonType switch
            {
                IntComparisonType.Equal       => Value == value,
                IntComparisonType.NotEqual    => Value != value,
                IntComparisonType.GreaterThan => Value > value,
                IntComparisonType.LessThan    => Value < value,
                _ => false,
            };
        }
    }
}