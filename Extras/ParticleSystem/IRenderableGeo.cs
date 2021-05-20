using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    interface IRenderableGeo
    {

        public List<Particle> MyParticles { get; set; }
        //public Vector EmitPos;
        //public string Name;
        
        public abstract void StartParticle(Particle inparticle);
        public abstract void UpdateParticles();
        public abstract string ToString();
        
    }
}
