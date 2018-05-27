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
    public class ProjectFactory : IFactory<IProject>
    {
        //This needs to become a singleton and we can remove the interface because it's not needed.
        public T LoadProject<T>(string text)
        {
            T project = JsonConvert.DeserializeObject<T>(text);
            if(project != null)
            {
                return project;
            }
            throw new ProjectLoadFailureException("Project could not be loaded from passed text");
        }

        public T LoadProjectFromPath<T>(string Path)
        {
            try
            {
               return JsonConvert.DeserializeObject<T>(File.ReadAllText(Path));
            }
            catch(ProjectLoadFailureException exception)
            {
                Console.WriteLine($"An exception occured {exception.HResult}");
            }
            throw new ProjectLoadFailureException();
        }

        public async void SaveProject(string location, IProject project)
        {
            using (StreamWriter writer = new StreamWriter(location, false, Encoding.Default))
            {
                await writer.WriteAsync(JsonConvert.SerializeObject(project, Formatting.Indented));
                //Probably need to take the return but we could also throw an exception if it can get that far
            }

            throw new Exception();
        }


        public T Get<T>(string location)
        {
            switch ((typeof(T).Name))
            {
                case "CSharpProject" :
                    if (!string.IsNullOrEmpty(location))
                    {
                        return LoadProjectFromPath<T>(location);
                    }
                    break;
                case "CPPProject":
                    return LoadProjectFromPath<T>(location);
                    break;
                default:
                    throw new ProjectLoadFailureException();
            }
            throw new ProjectLoadFailureException();
        }
    }
}
