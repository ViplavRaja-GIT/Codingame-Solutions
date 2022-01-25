// https://www.codingame.com/ide/puzzle/cosmic-love
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Planet{
    public string name;
    public double density;
    public double dis;
    public double radius;
    public Planet(string n, double r, double d, double c)
    {
        name = n;
        radius = r;
        density = d;
        dis = c;
    }
}
class Solution
{
    static double GetDensity(double r, double m)
    {
        return m/((4.0/3.0)*Math.PI*Math.Pow(r,3));
    }

    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        List<Planet> planets = new List<Planet>();
        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            string name = inputs[0];
            double r = double.Parse(inputs[1], System.Globalization.NumberStyles.Float);
            double m = double.Parse(inputs[2], System.Globalization.NumberStyles.Float);
            double c = double.Parse(inputs[3], System.Globalization.NumberStyles.Float);
            planets.Add(new Planet(name, r, GetDensity(r, m), c));
        }
        Planet alice = planets.FirstOrDefault(x => x.name == "Alice");
        foreach(var p in planets.OrderBy(x => x.dis))
        {
            if(p.name == "Alice")
                continue;
            double raochLimit = alice.radius * Math.Pow(2*(alice.density/p.density), 1.0/3.0);
            if(p.dis > raochLimit)
            {
                Console.WriteLine(p.name);
                break;
            }
        }
    }
}