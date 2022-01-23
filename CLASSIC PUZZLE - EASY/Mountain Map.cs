// https://www.codingame.com/ide/puzzle/mountain-map
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
    static void GetMountain(int height, int width, ref List<string> mount)
    {
        if (height < 0)
            return;
        string w = "/" + string.Join("", Enumerable.Repeat(" ", height * 2)) + "\\";
        if (w.Length != width)
        {
            int x = (width - w.Length) / 2;
            w = string.Join("", Enumerable.Repeat(" ", x)) + w + string.Join("", Enumerable.Repeat(" ", x));
        }
        mount.Add(w);
        GetMountain(height - 1, width, ref mount);
    }

    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()); // the number of mountains
        int[] inputs = Console.ReadLine().Split(' ').Select(x => int.Parse(x + "")).ToArray();
        int max = inputs.Max();
        List<List<string>> dts = new List<List<string>>();

        for (int i = 0; i < n; i++)
        {
            List<string> m = new List<string>();
            GetMountain(inputs[i] - 1, inputs[i] * 2, ref m);
            int count = m.Count();
            for (int a = 0; a < max - count; a++)
                m.Add(string.Join("", Enumerable.Repeat(" ", count * 2)));
            m.Reverse();
            dts.Add(m);
        }

        List<string> result = new List<string>();
        for (int i = max - 1; i >= 0; i--)
        {
            string r = "";
            for (int j = 0; j < n; j++)
            {
                r += dts[j].ElementAtOrDefault(i);
            }
            result.Add(r.TrimEnd());
        }

        result.Reverse();
        foreach (var r in result)
            Console.WriteLine(r);
    }
}