
namespace AnjinFilesTool.Event.Events
{
    public class FunctionProcessEvent : Event<FunctionProcessEvent>
    {
        public static EventHandler<FunctionProcessEvent> EventHandler { get; } = new EventHandler<FunctionProcessEvent>();
        public override EventHandler<FunctionProcessEvent> Handler => EventHandler;
        public double CurrentProgress { get; private set; }
        public string Info { get; private set; }
        public FunctionProcessEvent(double current, string info)
        {
            CurrentProgress = current;
            Info = info;
        }
    }
}
