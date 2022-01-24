// https://www.codingame.com/ide/puzzle/number-derivation
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
    private static int deriveRecursive(int n){
        for (int i = 2; i <=n/2 ; i++)
            if(n%i==0) {
                return (deriveRecursive(n / i) * i) + n / i;
            }
        return 1;
    }

    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(deriveRecursive(n));
    }
}