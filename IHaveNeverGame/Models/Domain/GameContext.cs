namespace IHaveNeverGame.Models.Domain
{
    public class GameContext
    {
        public static int CountOfShots { get; set; }
        public GameContext() => CountOfShots = default;
    }
}
