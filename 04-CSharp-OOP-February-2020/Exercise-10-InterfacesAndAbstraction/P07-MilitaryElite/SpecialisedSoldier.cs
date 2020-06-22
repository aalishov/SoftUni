using P07_MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_MilitaryElite
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public Corps Corp { get ; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine( base.ToString());
            sb.AppendLine($"Corps: {this.Corp}");
            return sb.ToString().TrimEnd();
        }
    }
}
