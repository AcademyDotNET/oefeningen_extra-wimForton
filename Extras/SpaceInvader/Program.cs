using System;

namespace SpaceInvader
{
    class Program
    {
        static void Main(string[] args)
        {
            StartGame();
        }

        private static void StartGame()
        {
            Console.CursorVisible = false;
            EnemyUfo myEnemyUfo1 = new EnemyUfo();
            EnemyUfo myEnemyUfo2 = new EnemyUfo();
            Rocket myRocket1 = new Rocket();
            Rocket myRocket2 = new Rocket();
            int test = 0;
            /*
            for (int i = 0; i < 50; i++)
            {
                myEnemyUfo1.Draw();
                System.Threading.Thread.Sleep(20);
            }
            */
            ConsoleKey myKey = Console.ReadKey(true).Key;
            //char key = 'i';
            do
            {
                while (!Console.KeyAvailable)
                {
                    myEnemyUfo1.Draw();
                    myEnemyUfo2.Draw();
                    System.Threading.Thread.Sleep(1);
                }
            } while (myKey != ConsoleKey.Escape);

        }
    }
}
