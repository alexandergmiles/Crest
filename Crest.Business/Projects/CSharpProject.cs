using Crest.Data;
using Crest.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crest.Data.Projects
{
    public class CSharpProject : Project
    {
        public CSharpProject(string name, string creatorUsername, IList<string> languagesUsed)
        {
            Name = name;
            CreatedDate = DateTime.Now;
            CreatedUsername = creatorUsername;
            LanguagesUsed = languagesUsed;
        }
    }
}
