﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism_Assignment
{
    // 1. Create an abstract class called Person with two properties: string firstName and string lastName
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // 2. Give it the method SayName()
        public abstract void SayName();
    }
}
