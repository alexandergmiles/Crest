﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Crest.Data;


namespace Crest.Data.Interfaces
{
    public interface IFactory<T> where T : IProject
    {
         T LoadProject<T>(string text);
         T LoadProjectFromPath<T>(string path);
         bool SaveProject(string location, IProject project);
         T Get<T>(string location);
    }
}
