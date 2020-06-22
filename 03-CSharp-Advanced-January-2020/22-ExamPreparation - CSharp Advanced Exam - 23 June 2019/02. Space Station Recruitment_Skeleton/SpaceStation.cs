using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        public string Name { get; set; }
        public int Capacity { get;  set; }

        private readonly List<Astronaut> data;

        public int Count
        {
            get
            {
                return data.Count;
            }
            private set { }

        }

        public SpaceStation(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Astronaut>(capacity);
        }

        public void Add(Astronaut astronaut)
        {
            if (data.Count < Capacity)
            {
                data.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            Astronaut astronaut = data.FirstOrDefault(x => x.Name == name);
            if (astronaut != null)
            {
                data.Remove(astronaut);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Astronaut GetOldestAstronaut()
        {
            Astronaut astronaut = data.OrderByDescending(x => x.Age).FirstOrDefault();
            return astronaut;
        }

        public Astronaut GetAstronaut(string name)
        {
            Astronaut astronaut = data.FirstOrDefault(x => x.Name == name);
            return astronaut;
        }



        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (var astronaut in data)
            {
                sb.AppendLine(astronaut.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
