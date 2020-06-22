using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Telephony
{
    public class StationaryPhone : ICalling
    {
        public string Call(string number)
        {
            return $"Dialing... {number}";
        }
    }
}
