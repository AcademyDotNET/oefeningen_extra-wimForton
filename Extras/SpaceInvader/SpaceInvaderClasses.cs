using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvader
{
    class Rocket
    {
        private bool Available = true;
        public void Draw()
        {

        }
    }
    class EnemyUfo{
        private double windForceX = 0;
        private double windForceY = 0;
        private Random windRandom = new Random();
        private int xPositionPrev = 20;
        private int yPositionPrev = 2;

        public void Draw()// todo: test if redraw needed
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(xPositionPrev, yPositionPrev);// (xPositionPrev, yPositionPrev);
            Console.Write("(= V =)");
            Console.SetCursorPosition(xPositionPrev, yPositionPrev + 1);
            Console.Write("   !   ");
            System.Threading.Thread.Sleep(2);
            Console.ForegroundColor = ConsoleColor.Blue;
            int[] NewPositions = CalculatePosition();
            Console.SetCursorPosition(NewPositions[0], NewPositions[1]);
            Console.Write("(= V =)");
            Console.SetCursorPosition(NewPositions[0], NewPositions[1] + 1);
            Console.Write("   !   ");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private int[] CalculatePosition()
        {
            int[] returnPositions = new int[2];
            windForceX += (windRandom.NextDouble() - 0.5) * 2.0;
            windForceY += (windRandom.NextDouble() - 0.5) * 2.0;
            windForceX = Math.Clamp(windForceX, -2, 2);
            windForceY = Math.Clamp(windForceY, -1, 1);

            returnPositions[0] = xPositionPrev + (int)(windForceX);
            returnPositions[1] = yPositionPrev + (int)(windForceY);
            returnPositions[0] = Math.Clamp(returnPositions[0], 5, 50);
            returnPositions[1] = Math.Clamp(returnPositions[1], 2, 6);
            xPositionPrev = returnPositions[0];
            yPositionPrev = returnPositions[1];
            //Console.WriteLine(windForceX);
            return returnPositions;
        }
    }
}
