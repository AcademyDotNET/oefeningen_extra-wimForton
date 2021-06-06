using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class PolyObjectLoader : RenderableGeo, IRenderableGeo
    {
        public List<Vector> myPoints { get; set; } = new List<Vector>();
        public List<Vector> myUVs { get; set; } = new List<Vector>();
        public bool hasUVs { get; set; } = false;
        public List<Vector> myNormals { get; set; } = new List<Vector>();
        public bool hasNormals { get; set; } = false;
        public List<Polygon> myPolygons { get; set; } = new List<Polygon>();
        List<float> myVaoList { get; set; } = new List<float>();
        Vector RGBColor { get; set; } = new Vector(0,0.5,1);
        private string FilePath { get; set; }
        //public Vector Position { get; set; } = new Vector(0, 0, -30);
        public PolyObjectLoader(string inFilePath)
        {
            FilePath = inFilePath;
            //Position.Z = -30;
            LoadFromFile();
            UpdateVAO();

        }
        public override void UpdateVAO()
        {
            myVaoList.Clear();
            foreach (var poly in myPolygons)//We use only triangles in our engine 
            {
                VertexToVao(0, poly);
                VertexToVao(1, poly);
                VertexToVao(2, poly);
                if(poly.Vertices.Count == 4)//create 2 triangles per quad in the right order (or 1triangle per triangle)
                {
                    VertexToVao(2, poly);
                    VertexToVao(3, poly);
                    VertexToVao(0, poly);
                }
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
            Vector myUV = myUVs[poly.UVs[inVertexIndex]];
            myVaoList.Add((float)myUV.X);//OpenGL takes only 2 UV coordinates
            myVaoList.Add((float)myUV.Y);
            //Vector myColor = poly.Colors[inVertexIndex];
            //myVaoList.Add((float)myColor.X);
            //myVaoList.Add((float)myColor.Y);
            //myVaoList.Add((float)myColor.Z);
        }
        public override void Update() { }
        public void LoadFromFile()
        {
            using (StreamReader streamReader = new StreamReader(FilePath))
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
                    if (values[0] == "vt")
                    {
                        hasUVs = true;
                        Vector myUV = new Vector(Convert.ToDouble(values[1]), Convert.ToDouble(values[2]), Convert.ToDouble(values[3]));
                        myUV.Y *= -1;
                        myUVs.Add(myUV);
                    }
                    if (values[0] == "vn")
                    {
                        hasNormals = true;
                        Vector myNormal = new Vector(Convert.ToDouble(values[1]), Convert.ToDouble(values[2]), Convert.ToDouble(values[3]));
                        myNormals.Add(myNormal);
                    }
                    if (values[0] == "f")
                    {

                        Random myRandom = new Random();
                        Polygon mypoly = new Polygon();
                        Vector randomColor = new Vector(myRandom.NextDouble(), myRandom.NextDouble(), myRandom.NextDouble());
                        randomColor *= RGBColor;
                        for (int i = 1; i < values.Length; i++)
                        {
                            int vertice, verticeTex, verticeNorm;
                            string[] v_vt_vn = values[i].Split('/');
                            vertice = Convert.ToInt32(v_vt_vn[0]) - 1;//Convert 1 based (obj) to 0 based
                            mypoly.Vertices.Add(vertice);
                            if (v_vt_vn.Length > 1) 
                            { 
                                verticeTex = Convert.ToInt32(v_vt_vn[1]) - 1;
                                mypoly.UVs.Add(verticeTex);
                            }
                            if (v_vt_vn.Length > 2)
                            {
                                verticeNorm = Convert.ToInt32(v_vt_vn[2]) - 1;
                                mypoly.Normals.Add(verticeNorm);
                            }
                            
                            mypoly.Colors.Add(randomColor);
                        }
                        myPolygons.Add(mypoly);
                    }
                }
            }
        }

    }
}
