using P07_MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public List<IRepair> Repairs { get ; set ; }


        public Engineer()
        {
            Repairs = new List<IRepair>();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Repairs:");
            foreach (var r in Repairs)
            {
                sb.AppendLine(r.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
