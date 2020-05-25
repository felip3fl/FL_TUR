using System;
using System.Collections.Generic;
using System.Text;

namespace FL_TUR.Model
{
    public class BaseClass
    {
        public BaseClass()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
