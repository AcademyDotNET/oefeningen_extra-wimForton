using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class PolyObjectLoader : ParticleSystems, IRenderableGeo
    {
        public List<Vector> myPoints { get; set; } = new List<Vector>();
        public List<Polygon> myPolygons { get; set; } = new List<Polygon>();
        List<float> myVaoList { get; set; } = new List<float>();
        Vector RGBColor { get; set; } = new Vector(0,0.5,1);
        //public Vector Position { get; set; } = new Vector(0, 0, -30);
        public PolyObjectLoader()
        {
            //Position.Z = -30;
            LoadFromFile();
            UpdateVAO();
        }
        public override void UpdateVAO()
        {
            myVaoList.Clear();
            foreach (var poly in myPolygons)//create 2 triangles per quad in the right order
            {
                VertexToVao(0, poly);
                VertexToVao(1, poly);
                VertexToVao(2, poly);
                VertexToVao(2, poly);
                VertexToVao(3, poly);
                VertexToVao(0, poly);
            }
        }
        public override List<float> GetVAO() {//We don't update each frame, just return the list
            return myVaoList;
        }
        public void VertexToVao(int inVertexIndex, Polygon poly)
        {
            Vector myPoint = myPoints[poly.Vertices[inVertexIndex]] + Position;
            myVaoList.Add((float)myPoint.X);
            myVaoList.Add((float)myPoint.Y);
            myVaoList.Add((float)myPoint.Z);
            Vector myColor = poly.Colors[inVertexIndex];
            myVaoList.Add((float)myColor.X);
            myVaoList.Add((float)myColor.Y);
            myVaoList.Add((float)myColor.Z);
        }
        public override void Update() { }
        public void LoadFromFile()
        {
            using (StreamReader streamReader = new StreamReader(@"H:\cursus_informatica\extras\objTest\test.obj"))
            {
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    string[] values = line.Split(' ');

                    if(values[0] == "v")
                    {
                        Vector myPoint = new Vector(Convert.ToDouble(values[1]), Convert.ToDouble(values[2]), Convert.ToDouble(values[3]));

                        myPoints.Add(myPoint);
                    }
                    if (values[0] == "f")
                    {
                        Random myRandom = new Random();
                        Polygon mypoly = new Polygon();
                        Vector randomColor = new Vector(myRandom.NextDouble(), myRandom.NextDouble(), myRandom.NextDouble());
                        for (int i = 1; i < values.Length; i++)
                        {
                            int vertice = Convert.ToInt32(values[i]) - 1;//Convert 1 based (obj) to 0 based
                            mypoly.Vertices.Add(vertice);
                            
                            mypoly.Colors.Add(randomColor);
                        }
                        myPolygons.Add(mypoly);
                    }
                }
            }
        }

    }
}
