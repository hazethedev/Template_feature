using System;
using UnityEngine;

namespace hazethedev.StateMachine.Variables
{
    [Serializable]
    public class MachineVariableManager
    {
        [SerializeField] private BoolVariable[] m_BoolVariables;
        [SerializeField] private IntVariable[] m_IntVariables;
        [SerializeField] private FloatVariable[] m_FloatVariables;

        public void Set(string id, bool value)
        {
            foreach (var variable in m_BoolVariables)
            {
                if (variable.Id != id) continue;
                variable.Set(value);
                break;
            }
        }
        
        public void Set(string id, int value)
        {
            foreach (var variable in m_IntVariables)
            {
                if (variable.Id != id) continue;
                variable.Set(value);
                break;
            }
        }
        
        public void Set(string id, float value)
        {
            foreach (var variable in m_FloatVariables)
            {
                if (variable.Id != id) continue;
                variable.Set(value);
                break;
            }
        }
    }
}