// https://www.codingame.com/ide/puzzle/dead-mens-shot
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
    static bool IsInsidePolygon(int x, int y, List<int[]> polygon)
    {
        bool inside = false;
        for (int i = 0, j = polygon.Count() - 1; i < polygon.Count(); j = i++) {
            int xi = polygon[i][0]; int yi = polygon[i][1];
            int xj = polygon[j][0]; int yj = polygon[j][1];
            bool intersect = ((yi > y) != (yj > y)) && (x <= (xj - xi) * (y - yi) / (yj - yi) + xi);
            if (intersect) inside = !inside;
        }
        return inside;
    }

    static void Main(string[] args)
    {
        List<int[]> polygon = new List<int[]>();
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
            polygon.Add(Console.ReadLine().Split(' ').Select(x => int.Parse(x+"")).ToArray());
        int M = int.Parse(Console.ReadLine());
        for (int i = 0; i < M; i++)
        {
            int[] inputs = Console.ReadLine().Split(' ').Select(x => int.Parse(x+"")).ToArray();
            Console.WriteLine(IsInsidePolygon(inputs[0],inputs[1],polygon) ? "hit" : "miss");
        }
    }
}