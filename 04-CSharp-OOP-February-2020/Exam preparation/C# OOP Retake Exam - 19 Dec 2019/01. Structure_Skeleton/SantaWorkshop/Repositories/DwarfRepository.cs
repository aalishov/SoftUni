using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Repositories
{
    public class DwarfRepository : IRepository<IDwarf>
    {
        private readonly IList<IDwarf> data;

        public DwarfRepository()
        {
            this.data = new List<IDwarf>();
        }
        public IReadOnlyCollection<IDwarf> Models
        {
            get { return data.ToImmutableList(); }
        }

        public void Add(IDwarf model)
        {
            data.Add(model);
        }

        public IDwarf FindByName(string name)
        {
            return data.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IDwarf model)
        {
            return data.Remove(model);
        }
    }
}
