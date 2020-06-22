using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        public string Color { get; set; }
        public int Capacity { get; set; }

        private readonly List<Present> data;

        public Bag(string color, int capacity)
        {
            this.Color = color;
            this.Capacity = capacity;
            this.data = new List<Present>();
        }

        public void Add(Present present)
        {
            if (data.Count + 1 <= Capacity)
            {
                this.data.Add(present);
            }
        }

        public bool Remove(string name)
        {
            Present present = data.FirstOrDefault(x => x.Name == name);
            if (present != null)
            {
                data.Remove(present);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Present GetHeaviestPresent()
        {
            return data.OrderByDescending(x => x.Weight).FirstOrDefault();
        }

        public Present GetPresent(string name)
        {
            return data.FirstOrDefault(x => x.Name == name);
        }

        public int Count
        {
            get
            {
                return data.Count;
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Color} bag contains:");
            foreach (var p in data)
            {
                sb.AppendLine(p.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
