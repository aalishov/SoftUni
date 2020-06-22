using System;
using System.Collections.Generic;
using System.Text;

namespace AquariumAdventure
{
    public class Fish
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Fins { get; set; }
        public Fish(string name, string color, int fins)
        {
            this.Name = name;
            this.Color = color;
            this.Fins = fins;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Fish: {this.Name}");
            sb.AppendLine($"Color: {this.Color}");
            sb.AppendLine($"Number of fins: {this.Fins}");

            return sb.ToString().TrimEnd();
        }
    }
}
