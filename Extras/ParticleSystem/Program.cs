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
            myObjects.Add(new PolyObjectLoader(@"PionA.obj"));
            myObjects.Add(new PolyObjectLoader(@"PionB.obj"));
            myObjects.Add(new PolyObjectLoader(@"PionC.obj"));
            myObjects.Add(new PolyObjectLoader(@"PionD.obj"));
            myObjects.Add(new PolyObjectLoader(@"GanzenBord.obj"));

            RenderOpenGL testRender = new RenderOpenGl3DObject(myObjects, 30f, 1280, 720, "Ganzenbord 3D");
            testRender.Run();
        }
    }
}
