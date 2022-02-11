// https://www.codingame.com/ide/puzzle/army-ants
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
        string[] inputs = Console.ReadLine().Split(' ');
        int N1 = int.Parse(inputs[0]);
        int N2 = int.Parse(inputs[1]);
        string S1 = Console.ReadLine();
        string S2 = Console.ReadLine();
        int T = int.Parse(Console.ReadLine());
        S1 = string.Join("",S1.Reverse());
        char[] result = (S1+S2).Select(c => c).ToArray();

        for(int i = 1; i <= T; i++)
        {
            for(int j = 0; j < result.Length-1; j++){
                char f = result[j]; //First
                char n = result[j+1]; //Next
                if(S1.Contains(f) && S2.Contains(n)) // Ideal condition for swapping
                {
                    var temp = result[j];
                    result[j] = result[j+1];
                    result[j+1] = temp;
                    j++; // Jumping to next element
                }
            }
        }
        
        Console.WriteLine(string.Join("", result));
    }
}