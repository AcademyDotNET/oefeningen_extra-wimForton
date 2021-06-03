using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;



namespace GameEngine
{
    class ParticleProgram
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");


            List<IRenderableGeo> myObjects = LoadScene();
            myObjects[2].Position.Z = -30.0;
            myObjects[3].Position.Z = -30.0;
            myObjects[3].Position.X = 5;
            myObjects[2].UpdateVAO();
            myObjects[3].UpdateVAO();

            RenderOpenGL game = new RenderOpenGl3DObject(myObjects, 30f, 1024, 600, "WindowTitle");
            game.Run();
        }
        private static List<IRenderableGeo> LoadScene()
        {
            List<IRenderableGeo> myRenderObjects = new List<IRenderableGeo>();
            myRenderObjects.Add(new ParticleEmitter("EmitterA", 20, Vector.setNew(0, 0, -30), 0.12, -0.10, 0.9995, true, 2));
            myRenderObjects.Add(new ParticleTensionLine("RopeA", 30, 30, Vector.setNew(-5, 1.5, -30), Vector.setNew(0, 1.5, -30), 1.0, -0.00002, 0.993));
            myRenderObjects.Add(new PolyObjectLoader());
            myRenderObjects.Add(new PolyObjectLoader());
            //myParticleSystems.Add(new ParticleTensionLine("RopeB", 50, 6, Vector.setNew(10, 16, 0), Vector.setNew(20, 10, 20), 1.0, 0.004, 0.986));
            return myRenderObjects;
        }
    }
}
