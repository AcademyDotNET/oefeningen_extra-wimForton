using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    interface IRenderableGeo
    {
        public Vector Position { get; set; }
        public List<Particle> myParticles { get; set; }
        public abstract List<float> GetVAO();
        public abstract void UpdateVAO();
        //public abstract void StartParticle(Particle inparticle);
        public abstract void Update();
        public abstract string ToString();
        
    }
}
