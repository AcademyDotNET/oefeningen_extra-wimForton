using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameEngine;

namespace Ganzenbord
{
    class Player
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Unnamed";
        public string Avatar { get; set; } = "DefaultAvatar";
        public int turnsWaitedAtThisSquare { get; set; } = 0;
        public int[] Dice { get; set; } = { 0, 0 };
        public int position { get; set; } = 0;
        public Player(string inName, string inAvatar, int Id)
        {
            Name = inName;
            Avatar = inAvatar;
        }
        public void ThrowDice(Game inGame)
        {
            Random myRandom = new Random();
            Dice[0] = myRandom.Next(1, 7);
            Dice[1] = myRandom.Next(1, 7);
            position += Dice[0] + Dice[1];
            if (position > 63)
            {
                position = 63 - (position - 63);
                inGame.GameOutput($"Player {Name} bounces back", Vector.setNew(0.5, 1, 1));
                Dice[0] *= -1;
                Dice[1] *= -1;
            }
        }

    }
}
