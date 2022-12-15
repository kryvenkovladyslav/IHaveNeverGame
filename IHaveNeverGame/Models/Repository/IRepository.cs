using System.Collections.Generic;

namespace IHaveNeverGame.Models.Repository
{
    public interface IRepository<T>
    {
        public IEnumerable<T> Entities { get; }
        public void Update(T entity);
        public void AddRange(IEnumerable<T> entities);
    }
}
