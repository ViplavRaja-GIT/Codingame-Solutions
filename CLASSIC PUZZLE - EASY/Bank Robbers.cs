// https://www.codingame.com/ide/puzzle/bank-robbers
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
class Solution
{
    static void Main(string[] args)
    {
        int R = int.Parse(Console.ReadLine());
        int V = int.Parse(Console.ReadLine());
        int[] r = new int[R].Select(x => 0).ToArray();
        for (int i = 0; i < V; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            int C = int.Parse(inputs[0]);
            int N = int.Parse(inputs[1]);
            int minIndex  = r.Select((n, i) => new { index = i, value = n })
                        .OrderBy(item => item.value)
                        .First().index;
            r[minIndex] += int.Parse(""+(Math.Pow(10,N) * Math.Pow(5, C-N)));
        }

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(r.Max());
    }
}