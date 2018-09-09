using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Crest.Data;
using Crest.Data.Interfaces;
using Crest.Data.Exceptions;


namespace ConsoleAppUsedForDebugging
{
    class Program
    {
        static void Main(string[] args)
        {
            IProject myNewProject = new Project();
            ProjectFile newFile = new ProjectFile("CodeFIle.cs", "", FileType.Text);
            myNewProject.AddFile(newFile);
            Console.WriteLine($"{myNewProject.GetFiles().Count()}");
            Console.ReadLine(); 
        }
    }
}
