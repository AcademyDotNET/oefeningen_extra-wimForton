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
