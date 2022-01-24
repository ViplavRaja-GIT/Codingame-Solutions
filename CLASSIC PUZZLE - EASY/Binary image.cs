// https://www.codingame.com/ide/puzzle/binary-image
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
        int h = int.Parse(Console.ReadLine());
        List<string> res = new List<string>();
        for (int i = 0; i < h; i++)
        {
            var row = Console.ReadLine().Split(" ").Select((x,i) => string.Join("", Enumerable.Repeat(i%2 == 0 ? "." : "O", int.Parse(x))));
            res.Add(string.Join("", row));
        }
        if(res.Select(x => x.Length).Distinct().Count() > 1){
            Console.WriteLine("INVALID");
        } else {
            foreach(var d in res)
                Console.WriteLine(d);
        }
    }
}