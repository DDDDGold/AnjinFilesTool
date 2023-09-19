using static AnjinFilesTool.Event.Events.FilePathResetEvent;

namespace AnjinFilesTool.Event.Events
{
    public class FilePathResetEvent : Event<FilePathResetEvent>
    {
        public string Path { get; private set; }
        public ActionResult Result { get; private set; }
        public static EventHandler<FilePathResetEvent> EventHandler { get; } = new EventHandler<FilePathResetEvent>();

        public override EventHandler<FilePathResetEvent> Handler { get; } = EventHandler;

        public FilePathResetEvent(string path, ActionResult result)
        {
            Path = path;
            Result = result;
        }

        public enum ActionResult
        {
            SUCCESS,
            FILE_NOT_EXIST,
            IS_NOT_DIRECTORY

        }


    }
    public static class ActionResultExtention
    {
        public static bool IsSuccess(this ActionResult result)
        {
            return result == ActionResult.SUCCESS;
        }
    }

}
