//https://www.codingame.com/ide/puzzle/super-computer
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
class XY{
    public int X;
    public int Y;
    public XY(int x, int y){
        this.X = x;
        this.Y = y;
    }
}

class Solution
{

    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        List<XY> dss = new List<XY>();
        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int J = int.Parse(inputs[0]);
            int D = int.Parse(inputs[1]);
            dss.Add(new XY(J,J+D-1));
        }

        dss = dss.OrderBy(x => x.Y).ToList();
        int num = 1;
        var limit = dss[0].Y;
        for (int i = 0; i < N; i++)
        {
            if(limit < dss[i].X){
                limit = dss[i].Y;
                num++;
            }
        }
        Console.WriteLine(num);
    }
}