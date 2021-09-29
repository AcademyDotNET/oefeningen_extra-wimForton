using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class SpriteText : RenderableGeo, IRenderableGeo
    {
        //public List<Vector> myPoints { get; set; } = new List<Vector>();
        public List<Vector> myUVs { get; set; } = new List<Vector>();
        public bool hasUVs { get; set; } = false;
        public List<Vector> myNormals { get; set; } = new List<Vector>();
        public bool hasNormals { get; set; } = false;
        public List<Polygon> myPolygons { get; set; } = new List<Polygon>();
        List<float> myVaoList { get; set; } = new List<float>();
        Vector RGBColor { get; set; } = new Vector(0, 0.5, 1);
        private string TextString { get; set; }
        //public Vector Position { get; set; } = new Vector(0, 0, -30);
        public SpriteText(string inString)
        {
            TextString = inString;
            UpdateVAO();

        }
        private void StringToPoly()
        {
            for (int i = 0; i < TextString.Length; i++)
            {
                char myChar = TextString[i];
                int myAscii = (int)myChar;
            }
        }
        public override void UpdateVAO()
        {
            myVaoList.Clear();
            foreach (var poly in myPolygons)//We use only triangles in our engine 
            {
                VertexToVao(0, poly);
                VertexToVao(1, poly);
                VertexToVao(2, poly);
                if (poly.Vertices.Count == 4)//create 2 triangles per quad in the right order (or 1triangle per triangle)
                {
                    VertexToVao(2, poly);
                    VertexToVao(3, poly);
                    VertexToVao(0, poly);
                }
            }
        }
        public override List<float> GetVAO()
        {//We don't update each frame, just return the list
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
            Vector myNormal = myNormals[poly.Normals[inVertexIndex]];
            myVaoList.Add((float)myNormal.X);
            myVaoList.Add((float)myNormal.Y);
            myVaoList.Add((float)myNormal.Z);
            //Vector myColor = poly.Colors[inVertexIndex];
            //myVaoList.Add((float)myColor.X);
            //myVaoList.Add((float)myColor.Y);
            //myVaoList.Add((float)myColor.Z);
        }
        public override void Update() { }
    }
}
