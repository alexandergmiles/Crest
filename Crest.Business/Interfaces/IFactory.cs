using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Crest.Data;


namespace Crest.Data.Interfaces
{
    public interface IFactory<T> where T : IProject
    {
        T Get<U>(string location);
    }
}
