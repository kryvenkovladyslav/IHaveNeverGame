using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IHaveNeverGame.Models.Domain
{
    [Serializable]
    public class Player : Entity, IEquatable<Player>
    {
        public string Name { get; set; }
        public int ShotCount { get; set; }
        public long Score { get; set; }
        public bool IsInGame { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder
                .Append("Player { ")
                .Append("ID: " + ID + " ")
                .Append("Name: " + Name + " ")
                .Append("Score " + Score + " }");

            return stringBuilder.ToString();
        }
        public override bool Equals(object obj)
        {
            var player = obj as Player;
            if (player == null) return false;
            else return Equals(player);
        }
        public override int GetHashCode()
        {
            return (ID.ToString() + Name + Score.ToString()).GetHashCode();
        }
        public bool Equals([AllowNull] Player other)
        {
            return other == null ? false : ID.Equals(other.ID);
        }
    }
}
