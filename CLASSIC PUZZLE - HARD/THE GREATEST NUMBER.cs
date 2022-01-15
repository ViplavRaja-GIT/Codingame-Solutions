// https://www.codingame.com/training/hard/the-greatest-number
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        string input = Console.ReadLine();
        bool dot = input.Contains(".");
        bool neg = input.Contains("-");
        input = input.Replace(" .","").Replace(" -","").Replace(".","").Replace("-","").Trim();
        List<int> values = input.Split(" ").Select(x => int.Parse(x+"")).OrderBy(x => x).ToList();
        string res = string.Empty;
        if(!neg){
            values.Reverse();
        }
        if(dot && neg){
            res = "-"+values[0]+"."+string.Join("",values.GetRange(1, values.Count()-1));
        } else if(dot){
            res = string.Join("",values.GetRange(0, values.Count()-1))+"."+values[values.Count()-1];
        } else {
            res = (neg ? "-" : "" )+string.Join("",values);
        }
        decimal num = decimal.Parse(res, NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint);
        Console.WriteLine(num.ToString("G29"));
    }
}