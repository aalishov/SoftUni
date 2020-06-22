using System;
using System.Collections.Generic;
using System.Text;

namespace P07_MilitaryElite.Interfaces
{
 public   interface IMission
    {
        public string CodeName { get; set; }
        public bool State { get; set; }
        public void CompleteMission();
    }
}
