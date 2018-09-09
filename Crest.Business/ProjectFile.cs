using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Crest.Data
{
    public class ProjectFile
    {
        public string Name { get; set; }
        public string FilePath { get; set; }
        public FileType FileType { get; set;  }

        public ProjectFile(string name, string filePath, FileType fileType)
            => (Name, FilePath, FileType) = (name, filePath, fileType);

    }
}
