﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class ArmoryException : Exception
    {
        public ArmoryException(string message) : base(message)
        {
        }
    }
}
