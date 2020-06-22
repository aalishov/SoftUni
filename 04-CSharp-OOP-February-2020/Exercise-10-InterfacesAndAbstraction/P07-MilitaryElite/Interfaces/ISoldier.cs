using System;
using System.Collections.Generic;
using System.Text;

namespace P07_MilitaryElite.Interfaces
{
    public interface ISoldier
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
