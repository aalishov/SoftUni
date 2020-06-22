using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count 
        { get 
            { return data.Count; }
            private set { } 
        }

        private List<Player> data;
        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.data = new List<Player>(capacity);
        }

        public void AddPlayer(Player player)
        {
            if (data.Count<Capacity)
            {
                data.Add(player);
            }
        }

        public  bool RemovePlayer(string name)
        {
            Player found = data.FirstOrDefault(x => x.Name == name);

            if (found!=null)
            {
                data.Remove(found);
                return true;
            }
            return false;
        }

        public void PromotePlayer(string name)
        {
            Player found = data.FirstOrDefault(x => x.Name == name);
            if (found!=null)
            {
                data.FirstOrDefault(x => x.Name == name).Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            Player found = data.FirstOrDefault(x => x.Name == name);
            if (found != null)
            {
                data.FirstOrDefault(x => x.Name == name).Rank = "Trial";
            }
        }

        public Player[] KickPlayersByClass(string classPlayer)
        {
            var returnAll = data.Where(x => x.Class == classPlayer).ToArray();
            data.RemoveAll(x => x.Class == classPlayer);
            return returnAll.ToArray();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");

            foreach (var p in data)
            {
                sb.AppendLine(p.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
