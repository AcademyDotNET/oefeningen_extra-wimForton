using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    abstract class RenderableGeo : IRenderableGeo
    {
        public List<Vector> myPoints { get; set; } = new List<Vector>();
        public List<Particle> myParticles { get; set; } = new List<Particle>();
        public Vector Position { get; set; } = new Vector(0, 0, 0);
        public string Name { get; set; } = "Unnamed";
        public abstract void Update();
        public virtual void UpdateVAO() { }
        public virtual List<float> GetVAO()
        {
            List<float> myVaoList = new List<float>();
            foreach (var item in myParticles)
            {
                myVaoList.Add((float)item.Pos.X - (float)(item.Size / 2));
                myVaoList.Add((float)item.Pos.Y - (float)(item.Size / 2));
                myVaoList.Add((float)item.Pos.Z);
                myVaoList.Add(0.0f);
                myVaoList.Add(0.0f);
                //myVaoList.Add((float)item.RGB.Z);
                myVaoList.Add((float)item.Pos.X);
                myVaoList.Add((float)item.Pos.Y + (float)(item.Size / 2));
                myVaoList.Add((float)item.Pos.Z);
                myVaoList.Add(0.5f);
                myVaoList.Add(1.0f);
                //myVaoList.Add((float)item.RGB.Z);
                myVaoList.Add((float)item.Pos.X + (float)(item.Size / 2));
                myVaoList.Add((float)item.Pos.Y - (float)(item.Size / 2));
                myVaoList.Add((float)item.Pos.Z);
                myVaoList.Add(1.0f);
                myVaoList.Add(0.0f);
                //myVaoList.Add(1.0f);
            }
            //float[] myVaoArray = myVaoList.ToArray();
            return myVaoList;

        }
        public override string ToString()
        {
            string particleString = "";
            foreach (var item in myParticles)
            {
                particleString += $"{item.Pos},";
                particleString += $"{item.RGB},";
                particleString += $"{item.Vel}";
                particleString += "\n";
            }
            return particleString;
        }
    }
}
