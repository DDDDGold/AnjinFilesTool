namespace AnjinFilesTool.Event.Events
{
    public class FilesChangedEvent : Event<FilesChangedEvent>
    {
        public static EventHandler<FilesChangedEvent> EventHandler { get; } = new EventHandler<FilesChangedEvent>();
        public override EventHandler<FilesChangedEvent> Handler => EventHandler;
        public bool IsChanged { get; private set; }
        public FilesChangedEvent(bool isChanged)
        {
            IsChanged = isChanged;
        }
    }
}
