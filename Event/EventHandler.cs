
namespace AnjinFilesTool.Event
{
    public delegate void Listener<E>(E e) where E : Event<E>;
    public class EventHandler<E> where E : Event<E>
    {
        private event Listener<E> _listener = e => { };


        public void RegisterListener(Listener<E> listener)
        {
            _listener += listener;
        }

        public void CallEvent(E e)
        {
            _listener(e);
        }
    }
}
