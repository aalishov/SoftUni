using System;
using System.Collections.Generic;
using System.Text;

namespace P07_MilitaryElite.Interfaces
{
    public interface ISpy : ISoldier
    {
        public int CodeNumber { get; set; }
    }
}
