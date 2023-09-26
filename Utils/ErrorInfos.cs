namespace AnjinFilesTool.Utils
{
    public static class ErrorInfos
    {
        public static string FailedToRenameBecauseExist(string from, string to)
        {
            return $"无法将文件'{from}'改名为'{to}'，原因：文件'{to}'在当前目录已存在。";
        }
    }
}
