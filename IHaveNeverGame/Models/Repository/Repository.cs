using IHaveNeverGame.Models.Domain;
using System.Collections.Generic;

namespace IHaveNeverGame.Models.Repository
{
    public class Repository<T> : IRepository<T>
    {
        public readonly Context context;
        public Repository(Context context) => this.context = context;

        public void AddRange(IEnumerable<T> entities)
        {
            context.AddRange<T>(entities);
        }

        public IEnumerable<T> GetAll()
        {
            return context.GetSet<T>();
        }
    }
}
