namespace AquaShop.Models.Aquariums
{
    using AquaShop.Models.Aquariums.Contracts;
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Models.Fish.Contracts;
    using AquaShop.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection.Metadata;
    using System.Text;

    public abstract class Aquarium : IAquarium
    {
        private readonly List<IDecoration> decorations;
        private readonly List<IFish> fish;
        private string name;

        protected Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }
                name = value;
            }
        }
        public int Capacity { get; }
        public int Comfort { get => Convert.ToInt32(decorations.Sum(x => x.Comfort)); }
        public ICollection<IDecoration> Decorations { get => this.decorations.AsReadOnly(); }
        public ICollection<IFish> Fish { get => this.fish.AsReadOnly(); }

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }
        public void AddFish(IFish fish)
        {
            if (this.fish.Count == this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            this.fish.Add(fish);
        }
        public void Feed()
        {
            foreach (var f in this.fish)
            {
                f.Eat();
            }
        }
        public string GetInfo()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");
            if (this.fish.Count == 0)
            {
                sb.AppendLine("Fish: none");
            }
            else
            {
                sb.AppendLine($"Fish: {string.Join(", ", fish.Select(x => x.Name))}");
            }            
            sb.AppendLine($"Decorations: {this.decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");
            return sb.ToString().TrimEnd();
        }
        public bool RemoveFish(IFish fish)
        {
            return this.fish.Remove(fish);
        }
    }
}
