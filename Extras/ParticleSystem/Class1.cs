using System;
using System.Collections.Generic;


public abstract class Shape
{
    public abstract double Opp();
}
class Circle : Shape
{
    private int Straal { get; set; }// deze allemaal private met autoproperty
    //Alle classes in een appart document zetten
    public Circle(int s)
    {
        Straal = s;
    }
    public override double Opp()
    {
        return Straal * Straal * Math.PI;
    }
}
class Square : Shape
{
    private  int Lengte { get; set; }
    public Square(int l)
    {
        Lengte = l;
    }
    public override double Opp()
    {
        return Lengte * Lengte;
    }
}
class OppBerekenaar
{
    private List<Shape> Lijst { get; set; }
    public OppBerekenaar()
    {
        Lijst = new List<Shape>();
    }
    public void VoegToe(Shape s)
    {
        Lijst.Add(s);
    }
    private double Sum()
    {
        double total = 0;
        foreach (Shape s in Lijst)
        {
            total += s.Opp();
        }
        return total;
    }
    public string Output()
    {
        return "<h1> Totale som = " + Sum() + " </h1> ";
    }
}