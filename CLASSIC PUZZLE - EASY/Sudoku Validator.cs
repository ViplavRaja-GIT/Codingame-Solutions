// https://www.codingame.com/ide/puzzle/sudoku-validator
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
{   static bool Validate(int[] arr)
    {
        return arr.Length == arr.Distinct().Count();
    }

    static bool ValidateRow(int[][] arr)
    {
        List<int[]> rows = new List<int[]>();
        foreach (var item in arr)
        {
            if(!Validate(item))
            {
                return false;
            }
        }
        return true;
    }


    static bool ValidateColumn(int[][] arr)
    {
        List<int[]> data =  new List<int[]>(new int[9][]).Select(x => new int[9]).ToList();
        for(int j = 0; j < arr.Length; j++)
        {
            for(int i = 0; i < arr[j].Length; i++)
            {
                var num = arr[j][i];
                data[i][j] = num;
            }
        }
        return ValidateRow(data.ToArray());
    }

    static bool ValidateGrid(int[][] arr){
        List<List<int>> grid = new  List<List<int>>();
        for(int a = 0; a < 9; a++)
            grid.Add(new List<int>()); 

        var x = 0;
        var y = 0; 
        for(int a = 0; a < 9; a++){
            int i = 0;
            while(i<3){
                int j = 0;
                while(j<3){
                    grid[a].Add(arr[x+i][y+j]);
                    j++;
                }
                i++;
            }
            x = x+3;
            if(x >= 9){
                x = 0;
                y = y+3;
            }
        }
        return ValidateRow(grid.Select(x => x.ToArray()).ToArray());
    }

    static void Main(string[] args)
    {
        int [][] arr = new int[9][];
        for (int i = 0; i < 9; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            arr[i] = new int[9];
            for (int j = 0; j < 9; j++)
            {
                int n = int.Parse(inputs[j]);
                arr[i][j] = n;
            }
        }
        Console.WriteLine((ValidateRow(arr) && ValidateColumn(arr) && ValidateGrid(arr)) ?  "true" : "false");
    }
}