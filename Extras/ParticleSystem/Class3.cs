using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    public enum Kleuren
    {
        geel,
        groen,
        blauw
    }
    public enum FilterMethod
    {
        color,
        size,
        name
    }
    public class Product
    {
        public string Naam { get; set; }
        public Kleuren Kleur { get; set; }
        public int Grootte { get; set; }
    }
    public class Filter
    {
        //List<Product> Tmp { get; set; }

        public static List<Product> FilterMethod(List<Product> lijst, Kleuren kleur) //kan je ook in 1 
        {

            List<Product> Tmp = new List<Product>();
            foreach (var p in lijst)
            {
                if (p.Kleur == kleur)
                    Tmp.Add(p);
            }
            return Tmp;
        }
        public static List<Product> FilterGrootte(List<Product> lijst, int inGrootte)
        {
            List<Product> Tmp = new List<Product>();
            foreach (var p in lijst)
            {
                if (p.Grootte == inGrootte)
                    Tmp.Add(p);
            }
            return Tmp;
        }
    }
}
