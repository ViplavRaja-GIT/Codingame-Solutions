// https://www.codingame.com/ide/puzzle/happy-numbers
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
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            List<int> loops =  new List<int>();
            string x = Console.ReadLine();
            int next = Convert.ToInt32(x.Select(x => Math.Pow(int.Parse(x+""),2)).Sum());
            while(next != 1 && !loops.Contains(next)){
                loops.Add(next);
                next = Convert.ToInt32(next.ToString().Select(x => Math.Pow(int.Parse(x+""),2)).Sum());
            }
            Console.WriteLine(next == 1 ? x+" :)" : x+" :(");
        }
    }
}