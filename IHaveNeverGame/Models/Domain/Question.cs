using System;

namespace IHaveNeverGame.Models.Domain
{
    [Serializable]
    public class Question : Entity
    {
        public string Text { get; set; }
    }
}
