using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnjinFilesTool.Core
{
    public class FileProxy
    {
        public string Name { get; set; }
        public FileSystemInfo File { get; private set; }

        public FileProxy(FileSystemInfo file)
        {
            Name = file.Name;
            File = file;
        }

    }
}
