using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquariumAdventure
{
    public class Aquarium
    {
        private HashSet<Fish> fishInPool;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Size { get; set; }

        public Aquarium(string name, int capacity, int size)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Size = size;
            this.fishInPool = new HashSet<Fish>(capacity);
        }

        public void Add(Fish fish)
        {
            if (fishInPool.FirstOrDefault(x=>x.Name==fish.Name)==null&&fishInPool.Count<this.Capacity)
            {
                fishInPool.Add(fish);
            }
        }

        public bool Remove(string name)
        {
            Fish fish = fishInPool.FirstOrDefault(x => x.Name == name);
            if (fish!=null)
            {
                fishInPool.Remove(fish);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Fish FindFish(string name)
        {
            return fishInPool.FirstOrDefault(x => x.Name == name);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Aquarium: {this.Name} ^ Size: {this.Size}");

            foreach (var fish in fishInPool)
            {
                sb.AppendLine(fish.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
