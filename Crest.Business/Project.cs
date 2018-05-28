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
    public class Project : IProject
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

        public Project(string name, string creator, IList<string> languagesUsed, ProjectType projectType)
        {
            Name = name;
            CreatedUsername = creator;
            LanguagesUsed = languagesUsed;
            CreatedDate = DateTime.Now;
            ProjectType = projectType;
        }
    }
}
