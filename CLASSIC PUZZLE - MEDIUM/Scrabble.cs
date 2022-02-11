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
   
    static int CalculatePoints(string value){
        Dictionary<char, int> vocubalry = new Dictionary<char, int>(){
            {'e',1},{'a',1},{'i',1},{'o',1},{'n',1},{'r',1},
            {'t',1},{'l',1},{'s',1},{'u',1},{'d',2},{'g',2},
            {'b',3},{'c',3},{'m',3},{'p',3},{'f',4},{'h',4},
            {'v',4},{'w',4},{'y',4},{'k',5},{'j',8},{'x',8},
            {'q',10},{'z',10}
        };
        int i = 0;
        foreach(char s in value){
            i+=vocubalry[s];
        }
        return i;
    }
    static void RemoveSimilar(Dictionary<string, int> data, string LETTERS){
        List<string> keys = new List<string>(data.Keys);
        foreach(var k in keys){
            for (var a = 0; a < k.Length; a++) {
                var numDic = k.Where(x => x==k[a]).Count();
                var numLet = LETTERS.Where(x => x==k[a]).Count();
                if (numDic > numLet) {
                     data.Remove(k);
                     break;
                }
            }
        }
    }

    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        Dictionary<string, int> powers = new Dictionary<string, int>();
        for (int i = 0; i < N; i++)
        {
            string W = Console.ReadLine();
            powers.Add(W, CalculatePoints(W));
        }
        string LETTERS = Console.ReadLine();
        powers = powers.OrderByDescending(x=> x.Value).ToDictionary(x => x.Key, x => x.Value);
        RemoveSimilar(powers, LETTERS);
        Console.WriteLine(powers.First().Key);
    }
}