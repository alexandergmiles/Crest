using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crest.Data.Interfaces
{
    public interface IProject
    {
        void AddFile(ProjectFile file);
        void RemoveFile(ProjectFile file);
        ObservableCollection<ProjectFile> GetFiles();
    }
}
