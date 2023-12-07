using System;
using System.Runtime.CompilerServices;
using TNRD;

namespace hazethedev.StateMachine.Utils
{
    public static class ConditionExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool AreMet(this ICondition[] conditions)
        {
            return Array.TrueForAll(conditions, Match);

            static bool Match(ICondition condition) => condition.IsMet();
        }
    }
}