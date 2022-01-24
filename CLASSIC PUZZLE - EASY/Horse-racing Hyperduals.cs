// https://www.codingame.com/ide/puzzle/horse-racing-hyperduals
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Horse{
    public int Velocity;
    public int Elegance;
    public Horse(int v, int e){
        Velocity = v;
        Elegance = e;
    }

    public int Diff(Horse h)
    {
        return Math.Abs(h.Velocity - this.Velocity) + Math.Abs(h.Elegance - this.Elegance);
    }
}
class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        List<Horse> horses = new List<Horse>();
        for (int i = 0; i < N; i++)
        {
            int[] inputs = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            horses.Add(new Horse(inputs[0],inputs[1]));
        }
        int diff = -1;
        for (int i = 0; i < N; i++)
        {
            for (int j = i+1; j < N; j++)
            {
                int newDiff = horses[i].Diff(horses[j]);
                if(diff == -1 || newDiff < diff)
                {
                    diff = newDiff;
                }   
            }
        }
        Console.WriteLine(diff);
    }
}