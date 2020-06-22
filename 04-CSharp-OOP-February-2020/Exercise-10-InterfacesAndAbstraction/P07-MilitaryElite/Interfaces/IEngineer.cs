using System;
using System.Collections.Generic;
using System.Text;

namespace P07_MilitaryElite.Interfaces
{
    public interface IEngineer:ISpecialisedSoldier
    {
        public List<IRepair> Repairs { get; set; }
    }
}
