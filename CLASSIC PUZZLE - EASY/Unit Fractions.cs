// https://www.codingame.com/ide/puzzle/unit-fractions
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
        long n = Convert.ToInt64(Console.ReadLine());
        long N = n * n;
        long i = 1;
        while (i < N / 2 + 1)
        {
            long x = n + (N / i);
            long y = n + i;
            if (x < y)
            {
                break;
            }
            if (N % i == 0)
            {
                Console.WriteLine("1/{0} = 1/{1} + 1/{2}", n, x, y);
            }
            i++;
        }
    }
}