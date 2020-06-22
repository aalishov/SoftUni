using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return data.Count;
            }
        }
        private readonly List<Rabbit> data;

        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            data = new List<Rabbit>(capacity);
        }

        public void Add(Rabbit rabbit)
        {
            if (data.Count+1<=Capacity)
            {
                data.Add(rabbit);               
            }
           
        }

        public bool RemoveRabbit(string name)
        {
            Rabbit rabbit = data.FirstOrDefault(x => x.Name == name);
            if (rabbit != null)
            {
                data.Remove(rabbit);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void RemoveSpecies(string species)
        {
            data.RemoveAll(x => x.Species == species);
        }

        public Rabbit SellRabbit(string name)
        {
            var rabbit = data.FirstOrDefault(x => x.Name == name);
            if (rabbit != null)
            {
                rabbit.Available = false;
                return rabbit;
            }
            else
            {
                return null;
            }
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            var rabbits = data.Where(x => x.Species == species).ToList();

            if (rabbits.Count>0)
            {

                foreach (var r in rabbits)
                {
                    r.Available = false;
                }
                return rabbits.ToArray();
            }
            return null;
        }

        public string Report()
        {
            var rabbits = data.Where(x => x.Available == true).ToList();
            StringBuilder s = new StringBuilder();
            s.AppendLine($"Rabbits available at {this.Name}:");
            foreach (var r in rabbits)
            {
                s.AppendLine(r.ToString());
            }
            return s.ToString().TrimEnd();
        }
    }
}
