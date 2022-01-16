// https://www.codingame.com/ide/puzzle/highest-truncated-pyramid
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
    static int GetNumber(int end, int num = 1){
        int index = num;
        int sum = num;
        while(sum < end){
            index++;
            sum+=index;
        }
        if(sum == end){
            return num;
        } else {
            return GetNumber(end,num+1);
        }
    }

    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        if(N==1){
            Console.WriteLine("*");
        } else {
            int get = GetNumber(N);
            int sum = get;
            for(int i = get; sum <= N; i++){
                Console.WriteLine(string.Join("",Enumerable.Repeat("*", i)));
                sum+=i;
            }
        }
    }
}