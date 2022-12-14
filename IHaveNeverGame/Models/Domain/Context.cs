using IHaveNeverGame.Models.Repository;
using System.Collections.Generic;

namespace IHaveNeverGame.Models.Domain
{
    public class Context
    {
        public IEnumerable<Player> Players { get; private set; }
        public IEnumerable<Question> Questions { get; private set; }
        public Context(IDataLoader<Question> dataLoader)
        {
            Questions = dataLoader.LoadData();
            Players = new List<Player>();
        }
    }
}
