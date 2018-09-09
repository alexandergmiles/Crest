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
            AssociatedFiles = new ObservableCollection<ProjectFile>();
        }

        //Inline beacuse who uses block statements for initalisation these days
        public Project(string name, string creator, IList<string> languagesUsed, ProjectType projectType)
            => (Name, CreatedUsername, LanguagesUsed, ProjectType, AssociatedFiles) = (name, creator, languagesUsed, projectType, new ObservableCollection<ProjectFile>());

        //Deconstructor so we can get the important deets ez pz with the use of discards (_)
        public void Deconstruct(out string name, out string creator, out IList<string> languagesUsed, ProjectType projectType) =>
            (name, creator, languagesUsed, projectType) = (Name, CreatedUsername, LanguagesUsed, ProjectType);
        
        public void AddFile(ProjectFile file)
        {
            AddFileToList(file);
        }

        public void RemoveFile(ProjectFile file)
        {
            RemoveFileFromList(file);
        }

        public ObservableCollection<ProjectFile> GetFiles()
        {
            return AssociatedFiles;            
        }


        #region Helper methods
        private IProject CreateProject(string text)
        {
            var project = JsonConvert.DeserializeObject<IProject>(text);
            if (project != null)
                return project;

            throw new ProjectLoadFailureException("Project could not be loaded from passed text");
        }

        private void AddFileToList(ProjectFile file)
        {
            if(file != null)
                AssociatedFiles.Add(file);
            else
                throw new NullReferenceException("File added is null");
        }

        private void RemoveFileFromList(ProjectFile file)
        {
            if (file != null)
                AssociatedFiles.Remove(file);
            else
                throw new NullReferenceException("File added is null");
        }

        private IProject CreateProjectFromPath(string Path)
        {
            if (!string.IsNullOrEmpty(Path))
                return JsonConvert.DeserializeObject<IProject>(File.ReadAllText(Path));

            throw new ProjectLoadFailureException();
        }

        private void SaveProject(string location, IProject project)
        {
            using (StreamWriter writer = new StreamWriter(location, false, Encoding.Default))
            {
                writer.Write(JsonConvert.SerializeObject(project, Formatting.Indented));
                //Probably need to take the return but we could also throw an exception if it can get that far
            }
        }

        #endregion
    }
}
