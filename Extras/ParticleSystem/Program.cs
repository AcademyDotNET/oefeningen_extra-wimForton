using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Ganzenbord;



namespace GameEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-GB");


            //List<IRenderableGeo> myObjects = LoadScene();
            List<IRenderableGeo> myObjects = new List<IRenderableGeo>();
            myObjects.Add(new UVsquare());
            myObjects.Add(new ParticleEmitter("test", 50, Vector.setNew(0,3,-20),0.1, -0.5, 0.999, true, 2));
            //myObjects.Add(new PolyObjectLoader(@"H:\cursus_informatica\extras\objTest\test.obj"));
            //myObjects[1].Position.Z = -20;
            //myObjects[1].UpdateVAO();
            //myObjects[3].UpdateVAO();

            RenderOpenGL testRender = new RenderOpenGl3DObject(myObjects, 30f, 1440, 720, "WindowTitle");
            testRender.Run();
        }
    }
}
