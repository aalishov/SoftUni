using P07_MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_MilitaryElite
{
    public class Private : Soldier, IPrivate
    {
        public decimal Salary { get ; set ; }
        public override string ToString()
        {
            return base.ToString()+$" Salary: {this.Salary:f2}";
        }
    }
   
}
