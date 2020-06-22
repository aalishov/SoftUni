namespace AquaShop.Repositories
{
    using AquaShop.Models.Decorations.Contracts;
    using AquaShop.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly List<IDecoration> data;
        public DecorationRepository()
        {
            this.data = new List<IDecoration>();
        }
        public IReadOnlyCollection<IDecoration> Models => this.data.AsReadOnly();

        public void Add(IDecoration model)
        {
            this.data.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            return data.FirstOrDefault(x => x.GetType().Name == type);

        }

        public bool Remove(IDecoration model)
        {
            return this.data.Remove(model);
        }
    }
}
