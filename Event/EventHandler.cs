
namespace AnjinFilesTool.Event
{
    public class EventHandler<E> where E : Event<E>
    {
        private List<Action<E>> _listener = new List<Action<E>>();


        public void RegisterListener(Action<E> listener)
        {
            _listener.Add(listener);
        }

        public void CallEvent(E e)
        {
            foreach (var item in _listener)
            {
                item.Invoke(e);
            }
        }
    }
}
