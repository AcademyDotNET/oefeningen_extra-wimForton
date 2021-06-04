using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    class UVsquare : ParticleSystems, IRenderableGeo
    {
        public List<Vector> myPoints { get; set; } = new List<Vector>();
        public List<Polygon> myPolygons { get; set; } = new List<Polygon>();
        List<float> myVaoList { get; set; } = new List<float>();
        Vector RGBColor { get; set; } = new Vector(0,0.5,1);
        private string FilePath { get; set; }
        //public Vector Position { get; set; } = new Vector(0, 0, -30);
        public UVsquare()
        {
            //vertex 1
            myVaoList.Add(-2.0f);
            myVaoList.Add(0.0f);
            myVaoList.Add(-6.0f);
            //vertex 2
            myVaoList.Add(0.0f);
            myVaoList.Add(1.0f);
            myVaoList.Add(-6.0f);
            //vertex 3
            myVaoList.Add(2.0f);
            myVaoList.Add(0.0f);
            myVaoList.Add(-6.0f);
            //UV 1
            myVaoList.Add(0.0f);
            myVaoList.Add(0.0f);
            //UV 2
            myVaoList.Add(0.5f);
            myVaoList.Add(1.0f);
            //UV 3
        }
        public override void UpdateVAO()
        {
        }
        public override List<float> GetVAO() {//We don't update each frame, just return the list
            return myVaoList;
        }
        public override void Update() { }
    }
}
