using IHaveNeverGame.Models.Domain;
using System.Collections.Generic;

namespace IHaveNeverGame.Models.Repository
{
    public class Repository<T> : IRepository<T>
    {
        public readonly Context context;
        public Repository(Context context) => this.context = context;    
    }
}
