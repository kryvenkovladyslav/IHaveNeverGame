using System.Collections.Generic;

namespace IHaveNeverGame.Models.Repository
{
    public interface IDataLoader<T>
    {
        public IEnumerable<T> LoadData();
    }
}
