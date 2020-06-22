using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public static class DataValidator
    {
        public static void Stats(int value, string type)
        {
            if (value < 0 || value > 100)
            {
                throw new Exception($"{type} should be between 0 and 100.");
            }
        }
        public static void Name(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new Exception("A name should not be empty.");
            }
        }
    }
}
