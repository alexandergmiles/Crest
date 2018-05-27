using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Crest.Data.Interfaces;
using Crest.Data.Exceptions;

using Newtonsoft.Json;
using System.IO;
using Crest.Data.Projects;

namespace Crest.Data
{
    public sealed class ProjectFactory
    {

        //Leaving this here as an example of the singleton pattern. Might need to use this later on and it'll be good to reference
        //back to.
        //private static readonly Lazy<ProjectFactory> lazy = new Lazy<ProjectFactory>(() => new ProjectFactory());

        //public static ProjectFactory Instance { get { return lazy.Value; } }

        private ProjectFactory()
        {

        }

        public static T Get<T>(string location)
        {
            switch (typeof(T).Name)
            {
                case "CSharpProject":
                    if (!string.IsNullOrEmpty(location))
                        return LoadProjectFromPath<T>(location);
                    break;
                case "CPPProject":
                    if (!string.IsNullOrEmpty(location))
                        return LoadProjectFromPath<T>(location);
                    break;
                default:
                    throw new ProjectLoadFailureException();
            }
            throw new ProjectLoadFailureException();
        }
        //Who cares about the methods that handle the loading?
        private static T LoadProject<T>(string text)
        {
            T project = JsonConvert.DeserializeObject<T>(text);
            if(project != null)
            {
                return project;
            }
            throw new ProjectLoadFailureException("Project could not be loaded from passed text");
        }

        private static T LoadProjectFromPath<T>(string Path)
        {
            if(!string.IsNullOrEmpty(Path))
                return JsonConvert.DeserializeObject<T>(File.ReadAllText(Path));

            throw new ProjectLoadFailureException();
        }

        private static async void SaveProject(string location, IProject project)
        {
            using (StreamWriter writer = new StreamWriter(location, false, Encoding.Default))
            {
                await writer.WriteAsync(JsonConvert.SerializeObject(project, Formatting.Indented));
                //Probably need to take the return but we could also throw an exception if it can get that far
            }
            throw new Exception();
        }


    }
}
