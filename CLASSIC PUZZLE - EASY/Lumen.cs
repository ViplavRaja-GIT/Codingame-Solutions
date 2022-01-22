// https://www.codingame.com/ide/puzzle/lumen
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

    static int printArray(string [,] s, int N){
        int count = 0;
        for (int i = 0; i < N; i++)
        {
            string cell = "";
            for (int j = 0; j < N; j++)
            {
                cell+=s[i,j];
                if(s[i,j] == "X")
                    count++;                
            }
            //Console.Error.WriteLine(cell);
        }
        return count;
    }

    static bool valid(int x, int y, int len)
    {
        return !(x<0 || y<0 || x > len-1 || y> len-1);
    }

    static void FillArray(ref string[,] str, int power, int x, int y, int N){
        if(str[x,y] == "X")
            str[x,y] = ""+power;
        if(power == 1){
            return;
        }
        //bottom
        if(valid(x+1, y, N)){
            FillArray(ref str, power-1, x+1, y, N);
        }
        //top
        if(valid(x-1, y, N)){
            FillArray(ref str, power-1, x-1, y, N);
        }
        //right
        if(valid(x, y+1, N)){
            FillArray(ref str, power-1, x, y+1, N);
        }
        //left
        if(valid(x, y-1, N)){
            FillArray(ref str, power-1, x, y-1, N);
        }

        //top right
        if(valid(x-1, y+1, N)){
            FillArray(ref str, power-1, x-1, y+1, N);
        }
        //top
        if(valid(x-1, y-1, N)){
            FillArray(ref str, power-1, x-1, y-1, N);
        }
        //right
        if(valid(x+1, y+1, N)){
            FillArray(ref str, power-1, x+1, y+1, N);
        }
        //left
        if(valid(x+1, y-1, N)){
            FillArray(ref str, power-1, x+1, y-1, N);
        }


    }

    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int L = int.Parse(Console.ReadLine());
        string[,] data = new string[N,N];
        List<string> candles = new List<string>();
        for (int i = 0; i < N; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            for (int j = 0; j < N; j++)
            {
                string cell = inputs[j];
                data[i,j] = cell;
                if(cell == "C"){
                    candles.Add(i+" "+j);
                }
            }
        }

        foreach(var str in candles)
        {
            var index = str.Split(" ").Select(int.Parse).ToArray();
            FillArray(ref data, L, index[0], index[1], N);
        }

        Console.WriteLine(printArray(data, N));
    }
}