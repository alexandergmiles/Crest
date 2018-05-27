using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crest.Data.Exceptions
{
    public class ProjectLoadFailureException : Exception
    {
        public ProjectLoadFailureException()
        {

        }

        public ProjectLoadFailureException(string message)
            : base(message)
        {

        }

        public ProjectLoadFailureException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
