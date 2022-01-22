// https://www.codingame.com/ide/puzzle/7-segment-scanner
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
    static int GetNum(string d)
    {
        switch (d)
        {
            case " _ | ||_|":
                return 0;
            case "     |  |":
                return 1;
            case " _  _||_ ":
                return 2;
            case " _  _| _|":
                return 3;
            case "   |_|  |":
                return 4;
            case " _ |_  _|":
                return 5;
            case " _ |_ |_|":
                return 6;
            case " _   |  |":
                return 7;
            case " _ |_||_|":
                return 8;
            case " _ |_| _|":
                return 9;
        }
        return 0;
    }

    static void Main(string[] args)
    {
        string line1 = Console.ReadLine();
        string line2 = Console.ReadLine();
        string line3 = Console.ReadLine();
        for (int i = 0; i < line1.Length; i += 3)
        {
            var x = line1.Substring(i, 3) + line2.Substring(i, 3) + line3.Substring(i, 3);
            Console.Write(GetNum(x));
        }
    }
}