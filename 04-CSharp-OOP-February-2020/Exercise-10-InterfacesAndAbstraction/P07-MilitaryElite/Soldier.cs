using P07_MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P07_MilitaryElite
{
    public abstract class Soldier : ISoldier
    {
        public string Id { get ; set ; }
        public string FirstName { get ; set; }
        public string LastName { get ; set ; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}";
        }
    }
}
