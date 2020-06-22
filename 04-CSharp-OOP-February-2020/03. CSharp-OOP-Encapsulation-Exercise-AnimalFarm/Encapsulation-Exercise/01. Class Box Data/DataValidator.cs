using System;
using System.Collections.Generic;
using System.Text;

namespace P01._Class_Box_Data
{
    public static class DataValidator
    {
        public static void ValidateSide(double number, string message)
        {
            if (number<0)
            {
                throw new ArgumentException($"{message} cannot be zero or negative.");
            }
        }
    }
}
