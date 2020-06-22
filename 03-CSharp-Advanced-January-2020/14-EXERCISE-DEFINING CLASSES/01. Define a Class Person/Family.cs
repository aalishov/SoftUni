using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            people = new List<Person>();
        }
        public List<Person> People
        {
            get { return people; }
            set { people = value; }
        }

        public void AddMember(Person member)
        {
            people.Add(member);
        }

        public Person GetOldestMember()
        {
            return people.OrderByDescending(x=>x.Age).First();
        }

        public List<Person> PeopleMoreThen30Ears()
        {
            return people.OrderBy(x => x.Name).Where(x => x.Age > 30).ToList();
        }

        
    }
}
