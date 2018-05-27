using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

using Crest.Data.Interfaces;
using Crest.Data.Exceptions;
using System.IO;
using Crest.Data;
using System.Collections.ObjectModel;

namespace Crest.Data
{
    public abstract class Project : IProject
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedUsername { get; set; }
        public IList<string> LanguagesUsed { get; set; }
        public ProjectType ProjectType { get; set;  }
        public string ProjectLocation { get; set; }
        public ObservableCollection<ProjectFile> AssociatedFiles { get; set; }

        public Project()
        {
        }

        public Project(string name, string user, IList<string> languagesUsed)
        {
            Name = name;
            CreatedDate = DateTime.Now;
            CreatedUsername = user;
            LanguagesUsed = languagesUsed;
        }
    }
}
