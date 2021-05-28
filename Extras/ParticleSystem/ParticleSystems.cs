using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    abstract class ParticleSystems// : IRenderableGeo
    {
        public List<Particle> myParticles = new List<Particle>();
        public Vector EmitPos = new Vector(0, 0, 0);
        public string Name { get; set; } = "Unnamed";
        public abstract void StartParticle(Particle inparticle);
        public abstract void UpdateParticles();
        public List<float> createVAO()
        {
            List<float> myVaoList = new List<float>();
            foreach (var item in myParticles)
            {
                myVaoList.Add((float)item.Pos.X - (float)(item.Size / 2));
                myVaoList.Add((float)item.Pos.Y - (float)(item.Size / 2));
                myVaoList.Add((float)item.Pos.Z);
                myVaoList.Add((float)item.RGB.X);
                myVaoList.Add((float)item.RGB.Y);
                myVaoList.Add((float)item.RGB.Z);
                myVaoList.Add((float)item.Pos.X);
                myVaoList.Add((float)item.Pos.Y + (float)(item.Size / 2));
                myVaoList.Add((float)item.Pos.Z);
                myVaoList.Add((float)item.RGB.X);
                myVaoList.Add((float)item.RGB.Y);
                myVaoList.Add((float)item.RGB.Z);
                myVaoList.Add((float)item.Pos.X + (float)(item.Size / 2));
                myVaoList.Add((float)item.Pos.Y - (float)(item.Size / 2));
                myVaoList.Add((float)item.Pos.Z);
                myVaoList.Add(1.0f);
                myVaoList.Add(1.0f);
                myVaoList.Add(1.0f);
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
