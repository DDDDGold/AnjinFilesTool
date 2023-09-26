using AnjinFilesTool.Event.Events;
using System.Text.RegularExpressions;

namespace AnjinFilesTool.Core
{
    public class FileManager
    {
        public static FileManager Instance { get; private set; } = new FileManager();
        public static Predicate<FileSystemInfo> SkipDirectory = f => !Directory.Exists(f.FullName);
        public string Path { get; private set; } = Application.StartupPath;
        private List<Predicate<FileSystemInfo>> _filters = new List<Predicate<FileSystemInfo>>();
        private DirectoryInfo _directory;
        private List<FileProxy> _files = new List<FileProxy>();
        public List<FileProxy> Files { get { return _files; } }
        public bool Changed { get; private set; } = false;
        public SearchType SearchType { get; set; } = SearchType.STRING;

        public FileManager()
        {
            _directory = new DirectoryInfo(Path);
            ResetPath(Application.StartupPath);
        }

        public void AddFilter(Predicate<FileSystemInfo> filter)
        {
            if (!_filters.Contains(filter))
            {
                _filters.Add(filter);
                ResetFiles();
            }
        }

        public void RemoveFilter(Predicate<FileSystemInfo> filter)
        {
            if (_filters.Remove(filter))
            {
                ResetFiles();
            }
        }


        public void ReplaceFileName(string keyword, string value)
        {
            bool changed = false;
            foreach (var file in _files)
            {
                if (replace(file, keyword, value))
                    changed = true;
            }
            if (changed)
            {
                SetChanged();
            }
        }

        public bool IsMatch(string name, string keyword)
        {
            if (SearchType == SearchType.STRING)
            {
                return name.Contains(keyword);
            }
            else if (SearchType == SearchType.REGEX)
            {
                return Regex.Match(name, keyword).Success;
            }
            return false;
        }

        private bool replace(FileProxy file, string keyword, string value)
        {
            if (SearchType == SearchType.STRING)
            {
                if (file.Name.Contains(keyword))
                {
                    file.Name = file.Name.Replace(keyword, value);
                    return true;
                }
            }
            else if (SearchType == SearchType.REGEX)
            {
                MatchCollection result = Regex.Matches(file.Name, keyword);
                if (result.Count > 0)
                {
                    string name = file.Name;
                    foreach (Match match in result)
                    {
                        GroupCollection groups = match.Groups;
                        string[] args = new string[groups.Count];
                        for (int i = 0; i < groups.Count; i++)
                        {
                            args[i] = groups[i].Value;
                        }
                        name = name.Replace(match.Value, string.Format(value, args));
                    }
                    file.Name = name;
                }
                return result.Count > 0;
            }
            return false;
        }

        public void SetFileName(int index, string name)
        {
            if (_files.Count > index)
            {
                if (_files[index].Name != name)
                {
                    _files[index].Name = name;
                    SetChanged();
                }
            }
        }

        public void SetChanged()
        {
            if (!Changed)
            {
                Changed = true;
                new FilesChangedEvent(true).Call();
            }
        }

        public void Save()
        {
            DirectoryInfo temp = CreateSubDic();
            string path = Path + (Path.EndsWith("\\") ? temp.Name : "\\" + temp.Name) + "\\";
            foreach (var file in _files)
            {
                if (file.Name != file.File.Name)
                {
                    string newPath = path + file.Name;
                    if (file.File is DirectoryInfo)
                    {
                        Directory.Move(file.File.FullName, newPath);
                    }
                    else if (file.File is FileInfo)
                    {
                        File.Move(file.File.FullName, newPath);
                    }
                }
            }
            path = Path.EndsWith("\\") ? Path : Path + "\\";
            foreach (var file in temp.GetFileSystemInfos())
            {
                string newPath = path + file.Name;
                if (file is DirectoryInfo)
                {
                    Directory.Move(file.FullName, newPath);
                }
                else if (file is FileInfo)
                {
                    File.Move(file.FullName, newPath);
                }
            }
            temp.Delete();
            ResetFiles();
            if (Changed)
            {
                Changed = false;
                new FilesChangedEvent(false).Call();
            }
        }

        private DirectoryInfo CreateSubDic()
        {
            string prefix = Path.EndsWith("\\") ? Path : Path + "\\";
            Random random = new Random();
            string name = random.NextInt64().ToString();
            while (Directory.Exists(prefix + name))
            {
                name = random.NextInt64().ToString();
            }
            return Directory.CreateDirectory(prefix + name);
        }

        public void ResetPath(string path)
        {
            FilePathResetEvent.ActionResult result;
            if (!Directory.Exists(path))
            {
                result = FilePathResetEvent.ActionResult.IS_NOT_DIRECTORY;
            }
            else if (File.Exists(path))
            {
                result = FilePathResetEvent.ActionResult.FILE_NOT_EXIST;
            }
            else
            {
                _directory = new DirectoryInfo(path);
                result = FilePathResetEvent.ActionResult.SUCCESS;
                Path = path;
                ResetFiles();
            }
            new FilePathResetEvent(path, result).Call();
        }

        private void ResetFiles()
        {
            if (_directory.Exists)
            {
                DirectoryInfo directory = _directory;
                _files.Clear();
                foreach (var file in directory.GetFileSystemInfos())
                {
                    bool flag = true;
                    int i = 0;
                    while (flag && i < _filters.Count)
                    {
                        flag = _filters[i++].Invoke(file);
                    }

                    if (flag)
                    {
                        _files.Add(new FileProxy(file));
                    }
                }
            }
            if (Changed)
            {
                Changed = false;
                new FilesChangedEvent(false).Call();
            }
        }
    }
}
