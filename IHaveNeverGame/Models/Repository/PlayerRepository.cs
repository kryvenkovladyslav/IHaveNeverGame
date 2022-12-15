using IHaveNeverGame.Models.Domain;
using System.Collections.Generic;
using System.Linq;

namespace IHaveNeverGame.Models.Repository
{
    public class PlayerRepository : IRepository<Player>
    {
        private List<Player> players;
        public IEnumerable<Player> Entities => players;
        public PlayerRepository() => players = new List<Player>();
        public void AddRange(IEnumerable<Player> entities) => players = entities.ToList();
        public void Update(Player entity)
        {
            var original = Entities.Where(player => player.ID == entity.ID).First();
            original.Name = entity.Name;
            original.Score = original.Score;
            original.ShotCount = original.ShotCount;
        }
    }
}
