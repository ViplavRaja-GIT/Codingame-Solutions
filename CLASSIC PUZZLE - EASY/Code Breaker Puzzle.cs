// https://www.codingame.com/ide/puzzle/code-breaker-puzzle
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
        string ALPHABET = Console.ReadLine();
        string MESSAGE = Console.ReadLine();
        string WORD = Console.ReadLine();
        int L = ALPHABET.Length;
        for(int i = 0; i< L; i++)
            for(int j = 0; j < L; j++)
            {
                var res = "";
                foreach(var m in MESSAGE)
                {
                    res += ALPHABET[((ALPHABET.IndexOf(m)+i)*j)%L];
                }
                if(res.Contains(WORD))
                {
                    Console.WriteLine(res);
                    return;
                }
            }
    }
}