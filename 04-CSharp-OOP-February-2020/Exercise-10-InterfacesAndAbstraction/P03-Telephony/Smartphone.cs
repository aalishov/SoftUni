using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Telephony
{
    public class Smartphone : ICalling, IBrowsing
    {
        public string Brows(string http)
        {
            return $"Browsing: {http}!";
        }

        public string Call(string number)
        {
            return $"Calling... {number}";
        }
    }
}
