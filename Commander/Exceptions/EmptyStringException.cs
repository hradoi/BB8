﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commander.Exceptions
{
    class EmptyStringException : Exception
    {
        public EmptyStringException() : base("Empty commandString.")
        {

        }
    }
}
