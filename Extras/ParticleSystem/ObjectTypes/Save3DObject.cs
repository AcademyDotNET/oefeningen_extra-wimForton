using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GameEngine
{
    class Save3DObject
    {
        public static void SaveToCSV(ParticleSystems inParticles, int frameNr, string fileName)
        {
            writeCsvStreamWriter(inParticles, frameNr, fileName);
        }
        public static void writeCsvStreamWriter(ParticleSystems inParticles, int frameNr, string fileName)
        {
            using (StreamWriter streamWriter = new StreamWriter(fileName + Convert.ToString(frameNr) + ".csv"))
            {
                streamWriter.Write(inParticles);
            }
        }
    }
    
}
