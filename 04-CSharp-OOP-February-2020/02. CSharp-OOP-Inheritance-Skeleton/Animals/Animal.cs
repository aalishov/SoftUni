using Animals.Enumerator;
using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        private int age;
        private string name;
        private Gender gender;
        public Animal(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            if (!(gender == "Male" || gender == "Female"))
            {
                throw new ArgumentException("Invalid input!");
            }
            else
            {
                this.Gender = Enum.Parse<Gender> (gender);
            }

        }
        public string Name
        {
            get { return this.name; }
            set
            {

                if (String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
                }
                else
                {
                    this.name = value;
                }
            }
        }
        public int Age
        {
            get { return this.age; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                else
                {
                    this.age = value;
                }
            }
        }
        public Gender Gender
        {
            get
            { return this.gender; }
            set
            {
                if (value == Gender.Male || value == Gender.Female)
                {
                    this.gender = value;
                }
                else
                {
                    throw new ArgumentException("Invalid input!");
                }
            }
        }

        public virtual string ProduceSound()
        {
            return null;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);
            sb.AppendLine($"{Name} {Age} {Gender}");
            sb.AppendLine(ProduceSound());
            return sb.ToString().TrimEnd();
        }
    }
}
