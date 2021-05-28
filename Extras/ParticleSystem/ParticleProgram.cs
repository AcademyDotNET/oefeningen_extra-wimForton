using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;



namespace ParticleSystem
{
    class ParticleProgram
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");
            //PlayParticles();
            //PlayParticleFactory();
            //TestStuff();

            List<ParticleSystems> myScene = LoadScene();
            Game game = new RenderOpenGl3DObject(myScene, 30f, 1024, 600, "WindowTitle");
            game.Run();
        }

        private static void TestStuff()
        {
            Vector test = new Vector(0.1, 4.0, 0.1);
            Vector test2 = new Vector(3.0, 2.0, 0.0);
            Console.WriteLine(Vector.length(test));
            Console.WriteLine((double)test);
            Console.WriteLine(Vector.Normalize (test));
            Console.WriteLine(Vector.CrossProduct(test, test2));
            test = new Vector(1.0, 4.0, 0.0);
            test2 = new Vector(1.0, 4.0, 0.0);
            //Console.WriteLine(test == test2);
            test2 = new Vector(1.0, 4.0, 0.0);
            //Console.WriteLine(test < test2);
            //Console.WriteLine(test >= test2);
        }
        private static void PlayParticleFactory()
        {
            /*
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(1, "ParticleEmitter");
            dictionary.Add(2, "ParticleTensionLine");
            dictionary.Add(3, "Motorbike");
            dictionary.Add(4, "Truck");
            dictionary.Add(5, "Bicycle");
            int chosenValue = 0;
            do
            {
                string UserInput = Console.ReadLine();
                chosenValue = Convert.ToInt32(UserInput);
            } while (chosenValue > 2 || chosenValue < 1);

            Console.WriteLine("Hoe wil je je emitter noemen?");
            string naam = Console.ReadLine();
            dictionary.TryGetValue(chosenValue, out string value);*/

            ParticleEmitter myParticleTemp = new ParticleEmitter(1);
            //var y = Type.GetType(myParticleTemp);
            var y = Type.GetType($"ParticleSystem.ParticleEmitter");
            Object[] args = { };//{ 50, Vector.setNew(1, 1, 1), 1.0, 1.0, 0.999 };
            //ParticleEmitter myParticle = (ParticleEmitter)Activator.CreateInstance(y);
            //ParticleEmitter myParticle = new ParticleEmitter();

            //Console.WriteLine($"You've build a {myParticle.GetType().Name}");
        }
        private static List<ParticleSystems> LoadScene()
        {
            List<ParticleSystems> myParticleSystems = new List<ParticleSystems>();
            myParticleSystems.Add(new ParticleEmitter("EmitterA", 100, Vector.setNew(0, 0, -30), 0.06, -0.030, 0.999, true, 2));
            myParticleSystems.Add(new ParticleTensionLine("RopeA", 30, 30, Vector.setNew(-5, 0, -30), Vector.setNew(5, 0, -30), 1.0, -0.00002, 0.993));
            myParticleSystems.Add(new ParticleTensionLine("RopeB", 50, 6, Vector.setNew(10, 16, 0), Vector.setNew(20, 10, 20), 1.0, 0.004, 0.986));
            return myParticleSystems;
        }
        private static void PlayParticles()
        {/*
            //Console.SetWindowSize(100, 50);
            int counter = 0;
            int frameNumber = 0;
            int samplesPerFrame = 5;
            int lastFrame = 1000;
            List<ParticleSystems> myParticleSystems = new List<ParticleSystems>();
            myParticleSystems.Add(new ParticleEmitter("EmitterA", 100, Vector.setNew(10, 16, 5), 0.1, 0.08, 0.99, true));
            myParticleSystems.Add(new ParticleTensionLine("RopeA", 30, Vector.setNew(10, 16, 0), Vector.setNew(40, 16, 0), 1.0, 0.004, 0.986));
            myParticleSystems.Add(new ParticleTensionLine("RopeB", 50, Vector.setNew(10, 16, 0), Vector.setNew(20, 10, 20), 1.0, 0.004, 0.986));

            Console.CursorVisible = false;
            while (counter < lastFrame * samplesPerFrame)
            {
                counter++;
                Console.SetCursorPosition(0, 0);
                Console.WriteLine($"sample: {counter}");

                //every Nth sample we write our ParticleSystems to a file
                if (counter%samplesPerFrame == 0)
                {
                    frameNumber++;
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine($"frameNumber: {frameNumber}");
                    foreach (var ParticleSystem in myParticleSystems)
                    {
                        Save3DObject.SaveToCSV(ParticleSystem, frameNumber, @"H:\cursus_informatica\Oefening_classes\ParticleSequence\" + ParticleSystem.Name);
                    }
                }
                //pull some ropes (not future proof)             
                myParticleSystems[1].myParticles[0].Pos.Z = Math.Sin((double)counter * 0.01) * 15;
                myParticleSystems[1].myParticles[myParticleSystems[1].myParticles.Count /2].Pos.Y = Math.Cos((double)counter * 0.04) * 8;
                myParticleSystems[2].myParticles[0].Pos.Z = Math.Sin((double)counter * 0.01) * 15;
                myParticleSystems[0].EmitPos = myParticleSystems[1].myParticles[myParticleSystems[1].myParticles.Count / 4].Pos;
                //dynamics
                for (int i = 0; i < myParticleSystems.Count; i++)
                {
                    myParticleSystems[i].UpdateParticles();
                }
            }*/
        }
    }
}
