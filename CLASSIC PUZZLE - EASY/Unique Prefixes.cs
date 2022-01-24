// https://www.codingame.com/ide/puzzle/unique-prefixes
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
    static void FixIt(Dictionary<string, List<string>> result)
    {
        Dictionary<string, List<string>> toAdd = new Dictionary<string, List<string>>();
        List<string> remove = new List<string>();
        foreach (var keyValue in result)
        {
            if (keyValue.Value.Count() > 1)
            {
                remove.Add(keyValue.Key);
                foreach (string s in keyValue.Value)
                {
                    int newL = keyValue.Key.Length + 1;
                    string[] data = s.Split(" ").ToArray();
                    string word = data[0];
                    string index = data[1]; 
                    if(newL > word.Length)
                        newL = word.Length;
                    string key = word.Substring(0, newL);
                    if (toAdd.ContainsKey(key))
                    {
                        toAdd[key].Add(word+" "+index);
                    }
                    else
                    {
                        toAdd.Add(key, new List<string>() { word+" "+index });
                    }
                }
            }
        }
        foreach (var re in remove)
            result.Remove(re);
        foreach (var k in toAdd)
            result.Add(k.Key, k.Value);
    }

    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();
        for (int i = 0; i < N; i++)
        {
            var w = Console.ReadLine();
            var key = w[0] + "";
            if (result.ContainsKey(key))
            {
                result[key].Add(w+" "+i);
            }
            else
            {
                result.Add(key, new List<string>() { w+" "+i });
            }
        }
        while (result.Count() < N)
        {
            FixIt(result);
        }
        Dictionary<int, string> finalResult = new Dictionary<int, string>();
        foreach (var res in result)
        {
            finalResult.Add(int.Parse(res.Value[0].Split(" ")[1]), res.Key);
        }
        finalResult = finalResult.OrderBy(x=> x.Key).ToDictionary(x => x.Key, x => x.Value);
        foreach (var str in finalResult)
            Console.WriteLine(str.Value);
    }
}