using System.Collections.Generic;

namespace IHaveNeverGame.Models.Repository
{
    public interface IRepository<T>
    {
        public IEnumerable<T> GetAll();
        public void AddRange(IEnumerable<T> entities);
    }
}
