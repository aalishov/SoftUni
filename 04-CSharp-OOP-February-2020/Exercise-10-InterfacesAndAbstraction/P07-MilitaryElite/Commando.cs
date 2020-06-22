using P07_MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public List<IMission> Missions { get; set; }

        public Commando()
        {
            Missions = new List<IMission>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");
            foreach (var m in Missions)
            {
                if (m.State==false)
                {
                    sb.AppendLine(m.ToString());
                }
                
            }
            return sb.ToString().TrimEnd();
        }
    }
}
