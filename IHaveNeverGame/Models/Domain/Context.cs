using IHaveNeverGame.Models.Repository;
using System.Collections.Generic;
using System.Linq;

namespace IHaveNeverGame.Models.Domain
{
    public class Context
    {
        public List<Player> Players { get; private set; }
        public List<Question> Questions { get; private set; }
        public Context(IDataLoader<Question> dataLoader)
        {
            Questions = dataLoader.LoadData().ToList();
            Players = new List<Player>();
        }
        public void AddRange<T>(IEnumerable<T> range)
        {
            if (typeof(T).Equals(typeof(Player))) Players.AddRange((IEnumerable<Player>)range);
            else Questions.AddRange((IEnumerable<Question>)range);
        }
        public IEnumerable<T> GetSet<T>()
        {
            if (typeof(T).Equals(typeof(Player))) return (IEnumerable<T>)Players;
            else return(IEnumerable<T>) Questions;
        }
    }
}
