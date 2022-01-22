// https://www.codingame.com/ide/puzzle/next-growing-number
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
        string n = Console.ReadLine();
        List<int> data = n.Select(x => int.Parse(x+"")).ToList();
        if(data[0] == 9){
            Console.WriteLine("1"+string.Join("", Enumerable.Repeat("1", data.Count())));
        } else {
            data = (Convert.ToInt64(n)+1).ToString().Select(x => int.Parse(x+"")).ToList();
            int next = -1;
            for(int i = 0; i < data.Count(); i++)
            {
                if(next != -1){
                   data[i] = next;
                   continue; 
                }
                if(i+1 < data.Count() && data[i] > data[i+1])
                {
                    data[i+1] = data[i];
                    next = data[i]; 
                }
            }
            Console.WriteLine(string.Join("", data));
        }
    }
}