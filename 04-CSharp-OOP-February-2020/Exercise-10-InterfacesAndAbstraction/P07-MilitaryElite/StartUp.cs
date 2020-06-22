using P07_MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;

namespace P07_MilitaryElite
{
    public class StartUp
    {
        private static Dictionary<string, ISoldier> soldiers = new Dictionary<string, ISoldier>();
        public static void Main()
        {
            while (true)
            {
                string[] line = Console.ReadLine().Split(' ');
                string cmd = line[0].ToLower();
                decimal salary = 0.0m;
                if (cmd == "end")
                {
                    break;
                }
                else if (cmd != "spy")
                {
                    salary = decimal.Parse(line[4]);
                }

                string id = line[1];
                string fName = line[2];
                string lName = line[3];




                if (soldiers.ContainsKey(id))
                {
                    throw new Exception("Soldier already exist!");
                }

                if (cmd == "private")
                {
                    Private p = new Private() { Id = id, FirstName = fName, LastName = lName, Salary = salary };


                    soldiers.Add(id, p);
                }
                else if (cmd == "lieutenantgeneral")
                {
                    LieutenantGeneral l = new LieutenantGeneral() { Id = id, FirstName = fName, LastName = lName, Salary = salary };
                    for (int i = 4; i < line.Length; i++)
                    {
                        string findId = line[i];
                        if (soldiers.ContainsKey(findId))
                        {
                            l.Privates.Add((IPrivate)soldiers[findId]);
                        }
                    }
                    soldiers.Add(id, l);
                }
                else if (cmd == "engineer")
                {
                    Corps corps = Enum.Parse<Corps>(line[5]);

                    Engineer e = new Engineer() { Id = id, FirstName = fName, LastName = lName, Salary = salary, Corp = corps };
                    for (int i = 6; i < line.Length; i += 2)
                    {
                        e.Repairs.Add(new Repair() { Name = line[i], HoursWorked = int.Parse(line[i + 1]) });
                    }
                    soldiers.Add(id, e);
                }
                else if (cmd == "commando")
                {
                    Corps corps = Enum.Parse<Corps>(line[5]);
                    Commando c = new Commando() { Id = id, FirstName = fName, LastName = lName, Salary = salary, Corp = corps };
                    for (int i = 6; i < line.Length; i += 2)
                    {
                        bool isFinished = line[i + 1] == "finished" ? true : false;
                        c.Missions.Add(new Mission() { CodeName = line[i], State = isFinished });
                    }
                    soldiers.Add(id, c);
                }
                else if (cmd == "spy")
                {
                    int codeNumber = int.Parse(line[3]);
                    Spy s = new Spy() { Id = id, FirstName = fName, LastName = lName, CodeNumber= codeNumber };
                    soldiers.Add(id, s);
                }
            }
            foreach (var s in soldiers)
            {
                Console.WriteLine(s.Value.ToString());
            }
        }
    }
}
