using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    class Draw3DObject
    {
        //public static void DrawParticlesToConsole(ParticleEmitter inParticles)
        //{
        //    foreach (var inParticle in inParticles.myParticles)
        //    {

            
        //        string drawString = inParticle.Object;
        //        Console.ForegroundColor = ColorConvert.RgbToConsole(inParticle.RGB);
        //        int prevx = (int)(inParticle.PrevPos.X * (inParticle.PrevPos.Z + 5) * 0.03 + 1.0) * 2;
        //        int prevy = (int)(inParticle.PrevPos.Y * (inParticle.PrevPos.Z + 5) * 0.03 + 1.0);
        //        int x = (int)(inParticle.Pos.X * (inParticle.Pos.Z + 5) * 0.03 + 1.0) * 2;
        //        int y = (int)(inParticle.Pos.Y * (inParticle.Pos.Z + 5) * 0.03 + 1.0);
        //        if (x < Console.WindowWidth && x > 0 && y < Console.WindowHeight && y > 0)
        //        {
        //            Console.SetCursorPosition(prevx, prevy);
        //            Console.WriteLine(" ");
        //            Console.SetCursorPosition(x, y);
        //            Console.WriteLine(drawString);
        //        }
        //    }
        //}
        public static void DrawParticlesToConsole2D(ParticleSystems inParticles)
        {
            foreach (var inParticle in inParticles.myParticles)
            {

                //Console.BackgroundColor = ConsoleColor.DarkMagenta;//ColorConvert.RgbToConsole(inParticle.RGB * 0.3);
                char drawChar = Convert.ToChar(inParticle.ParticleInstance);
                int prevx = (int)(inParticle.PrevPos.X * 2);
                int prevy = (int)(inParticle.PrevPos.Y);
                int x = (int)(inParticle.Pos.X * 2);
                int y = (int)inParticle.Pos.Y;
                if (prevx < Console.WindowWidth && prevx > 0 && prevy < Console.WindowHeight && prevy >= 0)
                {
                    Console.SetCursorPosition(prevx, prevy);
                    Console.WriteLine(" ");
                }
                Console.ForegroundColor = ColorConvert.RgbToConsole(inParticle.RGB);
                if (x < Console.WindowWidth && x > 0 && y < Console.WindowHeight && y >= 0)
                {
                    //if (inParticle.Age < 0.1) Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(x, y);
                    Console.Write(drawChar);                  
                }
            }
        }
        //public static void DrawSingleParticleToConsole2D(Particle<string> inParticle)
        //{
        //    string drawString = "X";// inParticle.Object;
        //    Console.ForegroundColor = ColorConvert.RgbToConsole(inParticle.RGB);
        //    int prevx = (int)(inParticle.PrevPos.X) * 2;
        //    int prevy = (int)(inParticle.PrevPos.Y);
        //    int x = (int)inParticle.Pos.X * 2;
        //    int y = (int)inParticle.Pos.Y;
        //    if (x < Console.WindowWidth && x > 1 && y < Console.WindowHeight - 4 && y > 0 && prevx < Console.WindowWidth && prevx > 1 && prevy < Console.WindowHeight - 4 && prevy > 0)
        //    {
        //        Console.SetCursorPosition(prevx, prevy);
        //        Console.WriteLine(" ");
        //        Console.SetCursorPosition(x, y);
        //        Console.WriteLine(drawString);
        //    }
        //}
    }
}
