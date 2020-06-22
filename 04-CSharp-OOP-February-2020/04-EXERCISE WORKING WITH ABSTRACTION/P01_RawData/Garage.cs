using P01_RawData.Enumerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01_RawData
{
    public class Garage
    {
        private readonly List<Car> data;

        public Garage()
        {
            data = new List<Car>();
        }

        public void Add(Car car)
        {
            data.Add(car);
        }

        public string Fragile()
        {
            StringBuilder sb = new StringBuilder();

            data.Where(x => x.Cargo.Type == Enum.Parse<CargoType>("fragile") && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList().ForEach(x => sb.AppendLine(x));

            return sb.ToString();
        }

        public string Flamable()
        {
            StringBuilder sb = new StringBuilder();

            data.Where(x => x.Cargo.Type == Enum.Parse<CargoType>("flamable") && x.Engine.Power > 250)
                   .Select(x => x.Model)
                   .ToList().ForEach(x => sb.AppendLine(x));

            return sb.ToString();
        }
    }
}
