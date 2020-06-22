using System;
using System.Collections.Generic;
using System.Text;

namespace P05_BirthdayCelebrations
{
    public interface IBirthable
    {
        public string BirthDay { get; set; }

        public bool IsInCurrentYear(string date)
        {
            string birthYear = this.BirthDay.Substring(this.BirthDay.Length - 4, 4);           
            if (birthYear == date)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string PrintBirthDate()
        { 
            return this.BirthDay; 
        }
    }
}
