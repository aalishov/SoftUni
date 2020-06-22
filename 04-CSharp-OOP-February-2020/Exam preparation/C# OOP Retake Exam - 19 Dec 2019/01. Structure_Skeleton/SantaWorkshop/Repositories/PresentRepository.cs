using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace SantaWorkshop.Repositories
{
    public class PresentRepository : IRepository<IPresent>
    {
        private readonly IList<IPresent> data;
        public PresentRepository()
        {
            this.data = new List<IPresent>();
        }
        public IReadOnlyCollection<IPresent> Models => data.ToImmutableList();

        public void Add(IPresent model)
        {
            data.Add(model);
        }

        public IPresent FindByName(string name)
        {
            return data.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IPresent model)
        {
            return data.Remove(model);
        }
    }
}
