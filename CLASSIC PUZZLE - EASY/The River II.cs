// https://www.codingame.com/ide/puzzle/the-river-ii-
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
        int r1 = int.Parse(Console.ReadLine());
        var res = false;
        for(int i = r1-1; i > 0 && !res; i--){
            int next = i+i.ToString().Select(x => int.Parse(x+"")).Sum();
            if(next == r1)
                res = true;
        }
        Console.WriteLine(res ? "YES" : "NO");
    }
}