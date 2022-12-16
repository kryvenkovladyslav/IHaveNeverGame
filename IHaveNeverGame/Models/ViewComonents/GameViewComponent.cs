using IHaveNeverGame.Models.Domain;
using System.Collections.Generic;

namespace IHaveNeverGame.Models.ViewComonents
{
    public class GameViewComponent
    {
        public List<Player> Players { get; set; }
        public List<Question> Questions { get; set; }
        public bool IsQuestionChangeed { get; set; }
        public long QuestionID { get; set; }
    }
}
