namespace AnjinFilesTool.Event
{
    public abstract class Event<E> where E : Event<E>
    {
        public abstract EventHandler<E> Handler { get; }
        public bool Call()
        {
            Handler.CallEvent((E)this);
            if (this is Cancellable c)
            {
                return !c.Cancelled;
            }
            return true;
        }

    }
}
