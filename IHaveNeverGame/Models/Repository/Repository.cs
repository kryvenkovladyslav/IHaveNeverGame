using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IHaveNeverGame.Models.Repository
{
    [Serializable]
    public class Repository<T> : IRepository<T>
    {
        public IEnumerable<T> Entities { get; set; }

        public Repository() { }
        public Repository(IEnumerable<T> entities) => Entities = entities;
    }
}
