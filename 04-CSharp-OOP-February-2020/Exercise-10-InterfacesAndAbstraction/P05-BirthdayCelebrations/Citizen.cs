﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P05_BirthdayCelebrations
{
    public class Citizen : Inhabitant,IBirthable

    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string BirthDay { get ; set ; }
    }
}
