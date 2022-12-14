using System.Collections.Generic;

namespace IHaveNeverGame.Models.Repository
{
    public interface IRepository<T>
    {
        public IEnumerable<T> Entities { get; set; }
    }
}
