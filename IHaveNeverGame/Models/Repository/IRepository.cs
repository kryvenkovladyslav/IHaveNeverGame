using System.Collections.Generic;

namespace IHaveNeverGame.Models.Repository
{
    public interface IRepository<T>
    {
        public IEnumerable<T> Entities { get; }
        public T GetByID(long id);
        public void Update(T entity);
        public void Delete(long id);
        public void AddRange(IEnumerable<T> entities);
    }
}
