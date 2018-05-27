using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Crest.Data;
using Crest.Data.Interfaces;
using Crest.Data.Projects;

namespace ConsoleAppUsedForDebugging
{
    class Program
    {
        static void Main(string[] args)
        {
            CSharpProject newProject = ProjectFactory.Get<CSharpProject>(@"C:\Users\Alexa\Desktop\Projects\newProject.prj");
            Console.WriteLine(newProject.Name);

            CPPProject secondProject = ProjectFactory.Get<CPPProject>(@"C:\Users\Alexa\Desktop\Projects\newProject.prj");
            Console.WriteLine(secondProject.Name);
            Console.ReadLine();
        }
    }
}
