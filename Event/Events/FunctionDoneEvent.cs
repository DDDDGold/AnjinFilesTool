
namespace AnjinFilesTool.Event.Events
{
    public class FunctionDoneEvent : Event<FunctionDoneEvent>
    {
        public static EventHandler<FunctionDoneEvent> EventHandler { get; } = new EventHandler<FunctionDoneEvent>();
        public override EventHandler<FunctionDoneEvent> Handler => EventHandler;

        public List<string> Errors { get; private set; }
        public FunctionResult Result { get; private set; }

        public FunctionDoneEvent(List<string> errors, FunctionResult result)
        {
            Errors = errors;
            Result = result;
        }



        public enum FunctionResult
        {
            Success,
            Fail
        }
    }
}
