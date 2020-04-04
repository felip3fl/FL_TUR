using System;
using System.Collections.Generic;
using System.Text;

namespace FL_TUR.Services
{
    class LimiteNumerosExluidosException : Exception
    {
        public LimiteNumerosExluidosException()
        {
            
        }

        public LimiteNumerosExluidosException(string message) : base(message)
        {

        }
    }
}
