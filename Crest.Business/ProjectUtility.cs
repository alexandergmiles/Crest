using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Crest.Data.Interfaces;
using Crest.Data.Exceptions;

using Newtonsoft.Json;
using System.IO;
using Crest.Data;

namespace Crest.Data
{
    public sealed class ProjectUtility
    {
        //Who cares about the methods that handle the loading?
        public static IProject CreateProject(string text)
        {
            var project = JsonConvert.DeserializeObject<IProject>(text);
            if(project != null)
            {
                return project;
            }
            throw new ProjectLoadFailureException("Project could not be loaded from passed text");
        }

        public static IProject CreateProjectFromPath(string Path)
        {
            if(!string.IsNullOrEmpty(Path))
                return JsonConvert.DeserializeObject<IProject>(File.ReadAllText(Path));

            throw new ProjectLoadFailureException();
        }

        public static void SaveProject(string location, IProject project)
        {
            using (StreamWriter writer = new StreamWriter(location, false, Encoding.Default))
            {
                writer.Write(JsonConvert.SerializeObject(project, Formatting.Indented));
                //Probably need to take the return but we could also throw an exception if it can get that far
            }
        }
    }
}
