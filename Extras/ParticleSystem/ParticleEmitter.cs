using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    class ParticleEmitter: ParticleSystems
    {
        //public List<Particle> myParticles = new List<Particle>();
        private double Gravity { get; set; } = 0;
        private double LifeSpan { get; set; }
        private bool RecycleParticles { get; set; } = false;
        private double Explosion { get; set; } = 0;
        private double Drag { get; set; } = 0.999;
        private Random myRandom = new Random();
        //private Vector color = new Vector(150, 255, 255);

        public ParticleEmitter(int input = 0)
        {
            Console.WriteLine("Bingo");
        }
        public ParticleEmitter(string inName, int inParticleMaxAmount = 20, Vector inEmitPos = null, double inExplosion = 1.0, double inGravity = 1.0, double friction = 0.999, bool recycle = false, double inLifeSpan = 2, double turbulenceStrength = 0, double turbulenceSize = 0)
        {
            Name = inName;
            Gravity = inGravity;
            EmitPos = inEmitPos;
            Explosion = inExplosion;
            Drag = friction;
            RecycleParticles = recycle;
            LifeSpan = inLifeSpan;
            for (int i = 0; i < inParticleMaxAmount; i++)
            {
                myParticles.Add(new Particle());
                StartParticle(myParticles[i]);
            }  
        }
        public override void StartParticle(Particle inParticle) {
            double velocityX = (myRandom.NextDouble() - 0.5) * Explosion;
            double velocityY = (myRandom.NextDouble() - 0.5) * Explosion;
            double velocityZ = (myRandom.NextDouble() - 0.5) * Explosion;
            inParticle.Pos = EmitPos;
            inParticle.Mass = myRandom.NextDouble() * 0.5;
            inParticle.Vel = new Vector(velocityX, velocityY, velocityZ);
            inParticle.Age = 0.0;
            inParticle.Drag  = Vector.setNew(Drag, Drag, Drag);
            inParticle.ParticleInstance = myRandom.Next(33, 122);
            inParticle.RGB = new Vector((int)myRandom.NextDouble(), (int)myRandom.NextDouble(), (int)myRandom.NextDouble());
            inParticle.Lifespan = LifeSpan + myRandom.NextDouble();
        }
        public override void UpdateParticles()
        {
            for (int i = 0; i < myParticles.Count; i++)
            {
                if (i < myParticles.Count)
                {
                    myParticles[i].PrevPos = myParticles[i].Pos;
                    myParticles[i].Age += 0.01;

                    if (myParticles[i].Age >= myParticles[i].Lifespan || (double)myParticles[i].Vel < 0.03)
                    {
                        if (RecycleParticles)
                        {
                            StartParticle(myParticles[i]);
                        }
                        else
                        {
                            myParticles.RemoveAt(i);
                            break;
                        }

                    }

                    CollideEdges(myParticles[i]);
                    myParticles[i].Vel *= myParticles[i].Drag;
                    myParticles[i].Vel.Y += myParticles[i].Mass * Gravity;

                    myParticles[i].Pos += myParticles[i].Vel;
                }
            }
        }
        public static void CollideEdges(Particle inParticle)
        {
            //if (inParticle.Pos.X >= Console.WindowWidth * 0.5 -2 || inParticle.Pos.X <= 1) inParticle.Vel.X *= -1;
            //if (inParticle.Pos.Y >= Console.WindowHeight - 4) inParticle.Vel.Y *= -1;
            if (inParticle.Pos.Y >= 70) inParticle.Vel.Y *= -0.9;
        }

    }
}
