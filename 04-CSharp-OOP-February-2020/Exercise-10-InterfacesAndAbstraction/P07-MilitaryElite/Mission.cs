using P07_MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_MilitaryElite
{
    public class Mission : IMission
    {
        public string CodeName { get; set; }
        public bool State { get ; set ; }

        public void CompleteMission()
        {
            this.State = true;
        }

        public override string ToString()
        {
            string progress = this.State == true ? "Finished" : "inProgress";
            return $"  Code Name: {this.CodeName} State: {progress}";
        }
    }
}
