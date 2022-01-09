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
    static int GetValue(Dictionary<string, int> values, string key)
    {
        if(values.ContainsKey(key)){
            return values[key];
        }
        return Convert.ToInt32(key);
    }

    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        List<string[]> instructions = new List<string[]>();
        Dictionary<string, int> values = new Dictionary<string, int>
        {
            { "a", int.Parse(inputs[0]) },
            { "b", int.Parse(inputs[1]) },
            { "c", int.Parse(inputs[2]) },
            { "d", int.Parse(inputs[3]) }
        };
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            instructions.Add(Console.ReadLine().Split(" "));
        }
        for(int i = 0; i < n;)
        {
            ParseValues(values, instructions[i], instructions, ref i);
        }
        Console.WriteLine(string.Join(" ",values.Values));
    }

    static void ParseValues(Dictionary<string, int> values, string [] data, List<string[]> ins, ref int crrIndex){
        switch(data[0]){
            case "MOV":
                values[data[1]] = GetValue(values, data[2]);
                crrIndex++;
                break;
            case "ADD":
                values[data[1]] = GetValue(values, data[2]) + GetValue(values, data[3]);
                crrIndex++;
                break;
            case "SUB":
                values[data[1]] = GetValue(values, data[2]) - GetValue(values, data[3]);
                crrIndex++;
                break;
            case "JNE":
                int line  = Convert.ToInt32(data[1]);
                int val = GetValue(values, data[3]);
                if(GetValue(values, data[2]) != val){
                    crrIndex = line;
                } else {
                    crrIndex++;
                }
                break;
        }
    }
}