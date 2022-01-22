// https://www.codingame.com/ide/puzzle/van-ecks-sequence
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

class Series
{
    private readonly List<int> Serie = new List<int>();
    private readonly Dictionary<int, int> ComparedNumbers = new Dictionary<int, int>();
    public Series(int start, int n)
    {
        this.Serie.Add(start);
        int count = 1;
        while (count != n)
        {
            int last = this.Serie.Last();
            if (ComparedNumbers.ContainsKey(last)) 
            {
                Serie.Add(count - ComparedNumbers[last]);
                ComparedNumbers[last] = count;
            }
            else
            {
                Serie.Add(0);
                ComparedNumbers.Add(last, count);
            }
            count++;
        }
    }
    public int Last() => this.Serie.Last();
}
 
class Solution
{
    static void Main(string[] args)
    {
        int A1 = int.Parse(Console.ReadLine());
        int N = int.Parse(Console.ReadLine());
        Console.WriteLine(new Series(A1, N).Last());
    }
}