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

            PolyObjectLoader testTorus = new PolyObjectLoader(@"H:/cursus_informatica/extras/Extras/ParticleSystem/bin/Debug/net5.0/GanzenBord.obj");
            Console.WriteLine(testTorus.myPolygons[0].Vertices[1]);
            Console.WriteLine(testTorus.myPolygons[0].UVs[1]);
            Console.WriteLine(testTorus.myPolygons[0].Normals[1]);
            
            List<IRenderableGeo> myObjects = new List<IRenderableGeo>();
            //myObjects.Add(new UVsquare());
            //myObjects.Add(new ParticleEmitter("test", 50, Vector.setNew(0,3,-20),0.1, -0.5, 0.999, true, 2));
            myObjects.Add(new PolyObjectLoader(@"GanzenBord.obj"));
            //myObjects[1].Position.Z = -20;
            //myObjects[1].UpdateVAO();
            //myObjects[3].UpdateVAO();

            RenderOpenGL testRender = new RenderOpenGl3DObject(myObjects, 30f, 1280, 720, "Ganzenbord 3D");
            testRender.Run();
        }
    }
}
