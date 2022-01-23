// https://www.codingame.com/ide/puzzle/brackets-extreme-edition
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Diagnostics;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        
        string expression = Console.ReadLine();
        Console.Error.WriteLine(expression);
        Dictionary<char,char> acc = new Dictionary<char, char>();
        acc.Add(')','(');
        acc.Add('}','{');
        acc.Add(']','[');
        Stack <char> data = new Stack<char>();
        foreach(var x in expression)
        {
            if(acc.Values.Contains(x)) {
                data.Push(x);
            } else if(acc.Keys.Contains(x)) {
                if(data.Count() == 0) {
                    Console.WriteLine("false");
                    return;
                } else {
                    if(acc[x] == data.Pop()){
                        continue;
                    } else {
                        Console.WriteLine("false");
                        return;
                    }
                }
            }
        }

        Console.WriteLine(data.Count() == 0 ? "true" : "false");
    }
}