using System;
using System.Collections.Generic;
using System.Text;

namespace P07_MilitaryElite.Interfaces
{
  public  interface ICommando:ISpecialisedSoldier
    {
        public List<IMission> Missions { get; set; }
    }
}
