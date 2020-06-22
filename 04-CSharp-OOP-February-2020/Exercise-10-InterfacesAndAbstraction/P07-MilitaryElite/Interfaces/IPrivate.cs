using System;
using System.Collections.Generic;
using System.Text;

namespace P07_MilitaryElite.Interfaces
{
    public interface IPrivate : ISoldier
    {
        public decimal Salary { get; set; }
    }
}
