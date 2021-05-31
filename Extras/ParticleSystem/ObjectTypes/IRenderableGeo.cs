using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    interface IRenderableGeo
    {

        public List<Particle> myParticles { get; set; }
        public abstract List<float> GetVAO();
        //public abstract void StartParticle(Particle inparticle);
        public abstract void Update();
        public abstract string ToString();
        
    }
}
