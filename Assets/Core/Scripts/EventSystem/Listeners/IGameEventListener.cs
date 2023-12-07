
namespace hazethedev.EventSystem
{
    public interface IGameEventListener<T>
    {
        void OnEventRaised(T item);
    }
}
