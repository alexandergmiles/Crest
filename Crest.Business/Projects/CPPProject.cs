using Crest.Data;
using Crest.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crest.Data.Projects
{
    public class CPPProject : Project
    {
        public CPPProject(string name, string creatorName, IList<string> langsUsed)
            : base(name, creatorName, langsUsed)
        {

        }
        public bool LoadProject(string text)
        {
            throw new NotImplementedException();
        }

        public bool LoadProjectFromPath(string Location)
        {
            throw new NotImplementedException();
        }

        public bool SaveProject(string Location, IProject project)
        {
            throw new NotImplementedException();
        }
    }
}
