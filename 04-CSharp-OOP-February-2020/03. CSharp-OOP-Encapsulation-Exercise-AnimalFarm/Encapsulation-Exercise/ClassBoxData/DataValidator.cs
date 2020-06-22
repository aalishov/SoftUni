using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
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
