// https://www.codingame.com/ide/puzzle/fax-machine
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
        int W = int.Parse(Console.ReadLine());
        int H = int.Parse(Console.ReadLine());
        List<int> T = Console.ReadLine().Split(" ").Select(x => int.Parse(x)).ToList();
        string r = "";
        for (int i = 0; i < T.Count(); i++)
        {
            r += string.Join("", Enumerable.Repeat(i % 2 == 0 ? "*" : " ", T[i]));
        }
        for (int i = 0; i < r.Length; i += W)
        {
            Console.WriteLine("|"+r.Substring(i, W)+"|");
        }
    }
}