using System;

namespace Kids_vs_IceCream
{
    public class Player : IComparable<Player>
    {
        public String Name { get; set; }

        public int Score { get; set; }

        public Player(String name, int score)
        {
            this.Name = name;
            this.Score = score;
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", this.Name, this.Score);
        }

        public int CompareTo(Player other)
        {
            return other.Score - this.Score;
        }
    }
}