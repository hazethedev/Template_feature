using System.Collections.Generic;
using UnityEngine;

namespace hazethedev.StateMachine
{
    public class StateMachineUpdateModule : MonoBehaviour, IMachineModule<IStateTick>
    {
        private HashSet<IStateTick> m_StatesToTick = new();
        
        void IMachineModule<IStateTick>.OnEnter(IStateTick stateComponent)
        {
            m_StatesToTick.Add(stateComponent);
            if (!enabled) enabled = true;
        }

        void IMachineModule<IStateTick>.OnExit(IStateTick stateComponent)
        {
            m_StatesToTick.Remove(stateComponent);
            if (m_StatesToTick.Count == 0) enabled = false;
        }

        private void Update()
        {
            var dt = Time.deltaTime;
            
            foreach (var state in m_StatesToTick)
                state.Tick(in dt);
        }
    }
}