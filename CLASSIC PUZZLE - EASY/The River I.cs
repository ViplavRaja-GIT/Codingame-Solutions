// https://www.codingame.com/ide/puzzle/the-river-i-
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
        long r1 = long.Parse(Console.ReadLine());
        long r2 = long.Parse(Console.ReadLine());
        while(r1 != r2)
        {
            if(r1 < r2) {
                r1 = r1+r1.ToString().Select(x => int.Parse(x+"")).ToList().Sum();
            } else {
                r2 = r2+r2.ToString().Select(x => int.Parse(x+"")).ToList().Sum();
            }
        }
        Console.WriteLine(r1);
    }
}