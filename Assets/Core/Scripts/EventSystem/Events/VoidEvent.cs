
using UnityEngine;

namespace hazethedev.EventSystem
{
    [CreateAssetMenu(fileName = "New Void Event", menuName = "EventSystem/Events/Void Event")]
    public class VoidEvent : GameEventBase<VoidType>
    {
        public void Raise() => Raise(new VoidType());
    }
}
