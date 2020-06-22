using System;
using System.Collections.Generic;
using System.Text;

namespace P07_MilitaryElite.Interfaces
{
  public  interface IRepair
    {
        public string Name { get; set; }
        public int HoursWorked { get; set; }
    }
}
