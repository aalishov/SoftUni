using P01_RawData.Enumerator;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Cargo
    {

        public Cargo(int weight, CargoType type)
        {
            this.Weight = weight;
            this.Type = type;
        }
        public int Weight { get; set; }
        public CargoType Type { get; set; }
    }
}
