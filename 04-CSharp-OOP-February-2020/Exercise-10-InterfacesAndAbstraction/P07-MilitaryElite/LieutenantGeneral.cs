using P07_MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public List<IPrivate> Privates { get ; set; }
        public LieutenantGeneral()
        {
            Privates = new List<IPrivate>();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");
            foreach (var p in Privates)
            {
                sb.AppendLine(p.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
