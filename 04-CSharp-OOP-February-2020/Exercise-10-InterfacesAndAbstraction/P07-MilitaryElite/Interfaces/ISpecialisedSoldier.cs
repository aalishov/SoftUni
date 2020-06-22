using System;
using System.Collections.Generic;
using System.Text;

namespace P07_MilitaryElite.Interfaces
{
  public  interface ISpecialisedSoldier:IPrivate
    {
        public Corps Corp { get; set; }
    }
}
