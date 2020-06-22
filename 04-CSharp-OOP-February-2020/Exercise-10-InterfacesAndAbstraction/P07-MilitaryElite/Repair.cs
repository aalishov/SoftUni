using P07_MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_MilitaryElite
{
    public class Repair : IRepair
    {
        public string Name { get ; set ; }
        public int HoursWorked { get ; set ; }
        public override string ToString()
        {
            return $"  Part Name: {this.Name} Hours Worked: {this.HoursWorked}";
        }
    }
}
