using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{/*
    public interface IParticleFactory
    {
    }
    public static class EmitterFactory
    {


        //public static IVehicle Build(int chosenValue)
        //{
        //    switch (chosenValue)
        //    {
        //        case 1:
        //            return new Unicycle();
        //        case 2:
        //            return new Motorbike();
        //        case 3:
        //            return new Car();
        //        default:
        //            return new Truck();
        //    }
        //}
        public static ParticleEmitter Build(string chosenValue, string naam)
        {
            //int aantalWielen = 0;
            var y = Type.GetType($"ParticleSystem.{chosenValue}");//ParticleSystem is de namespace
            Object[] args = { 50, Vector.setNew(1,1,1), 1.0, 1.0, 0.999};
            //int inParticleMaxAmount, Vector inEmitPos, double inExplosion, double inGravity, double friction, bool recycle = false, double turbulenceStrength = 0, double turbulenceSize = 0
            ParticleEmitter resultParticle = (ParticleEmitter)Activator.CreateInstance(y, args);
            return resultParticle;
        }
    }*/
}
