using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Child : Person
    {
        public Child(string name, int age)
    : base(name, age)
        {
        }

        public override int Age
        {
            get => base.Age;
            set
            {
                if (value >= 0 )
                {
                    base.Age = value;
                }
                else
                {
                    throw new ArgumentException("Age should be in interval 0-15!");
                }
            }
        }
    }
}
