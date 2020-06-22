using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> health = new Dictionary<string, int>();
        Dictionary<string, int> energy = new Dictionary<string, int>();

        string cmd = string.Empty;

        while (true)
        {
            cmd = Console.ReadLine();
            if (cmd == "Results")
            {
                break;
            }
            string[] line = cmd.Split(':');
            string command = line[0];
            switch (command)
            {
                case "Add":
                    string addName = line[1];
                    int addHealth = int.Parse(line[2]);
                    int addEnergy = int.Parse(line[3]);
                    if (!health.ContainsKey(addName))
                    {
                        health.Add(addName, addHealth);
                        energy.Add(addName, addEnergy);
                    }
                    else
                    {
                        health[addName] += addHealth;
                    }
                    break;
                case "Attack":
                    string attackerName = line[1];
                    string defenderName = line[2];
                    int damage = int.Parse(line[3]);
                    if (health.ContainsKey(attackerName) && health.ContainsKey(defenderName))
                    {
                        health[defenderName] -= damage;
                        if (health[defenderName] <= 0)
                        {
                            health.Remove(defenderName);
                            energy.Remove(defenderName);
                            Console.WriteLine($"{defenderName} was disqualified!");
                        }
                        energy[attackerName]--;
                        if (energy[attackerName] == 0)
                        {
                            health.Remove(attackerName);
                            energy.Remove(attackerName);
                            Console.WriteLine($"{attackerName} was disqualified!");
                        }
                    }
                    break;
                case "Delete":
                    string userName = line[1];

                    if (userName == "All")
                    {
                        health.Clear();
                        energy.Clear();
                    }
                    else if (health.ContainsKey(userName))
                    {
                        health.Remove(userName);
                        energy.Remove(userName);
                    }
                    break;
            }

        }
        Console.WriteLine($"People count: {energy.Count}");
        List<People> peoples = new List<People>();
        foreach (var item in health)
        {
            peoples.Add(new People(item.Key, item.Value));
        }
        foreach (var people in peoples)
        {
            people.Energy = energy[people.Name];
        }
        foreach (var r in peoples.OrderByDescending(x => x.Health).ThenBy(x => x.Name))
        {
            Console.WriteLine($"{r.Name} - {r.Health} - {r.Energy}");
        }
    }
    class People
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Energy { get; set; }
        public People(string name, int health)
        {
            this.Name = name;
            this.Health = health;
        }
    }
}

