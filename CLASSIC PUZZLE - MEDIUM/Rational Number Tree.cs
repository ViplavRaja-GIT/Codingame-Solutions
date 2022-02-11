// https://www.codingame.com/ide/puzzle/rational-number-tree

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
class Fraction{
    public long numerator;
    public long denominator;
    public Fraction(long n, long d){
        numerator = n;
        denominator = d;
    }

    public static bool operator ==(Fraction a, Fraction b)
    {
        return b.numerator == a.numerator && b.denominator == a.denominator;
    }
    
    public static bool operator !=(Fraction a, Fraction b)
    {
        return !(b == a);
    }

    public static bool operator <(Fraction e1, Fraction e2) 
    {
       return Convert.ToDouble(e1.numerator)/Convert.ToDouble(e1.denominator) < Convert.ToDouble(e2.numerator)/Convert.ToDouble(e2.denominator);
    }

    public static bool operator >(Fraction e1, Fraction e2) 
    {
        return Convert.ToDouble(e1.numerator)/Convert.ToDouble(e1.denominator) > Convert.ToDouble(e2.numerator)/Convert.ToDouble(e2.denominator);
    }

    public override string ToString() => $"{numerator}/{denominator}";
}

class Solution
{
    static string FractionToDirection(Fraction fraction){
        var minFraction = new Fraction(0,1);
        var targetFraction = new Fraction(1,1);
        var maxFraction = new Fraction(1,0);
        string result = "";
        while(fraction != targetFraction){
            if(fraction < targetFraction){
                maxFraction = targetFraction;
                result+="L";
            } else {
                minFraction = targetFraction;
                result+="R";
            }
            long num = minFraction.numerator + maxFraction.numerator;
            long deno = minFraction.denominator + maxFraction.denominator;
            targetFraction = new Fraction(num, deno);
        }
        return result;
    }

    static Fraction DirectionToFraction(string dir){
        var minFraction = new Fraction(0,1);
        var targetFraction = new Fraction(1,1);
        var maxFraction = new Fraction(1,0);
        foreach(var d in dir){
            if(d == 'L'){
                maxFraction = targetFraction;
            } else {
                minFraction = targetFraction;
            }
            long num = minFraction.numerator + maxFraction.numerator;
            long deno = minFraction.denominator + maxFraction.denominator;
            targetFraction = new Fraction(num, deno);
        }
        return targetFraction;
    }

    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        for (int i = 0; i < N; i++)
        {
            string line = Console.ReadLine();
            if(line.Contains("/")){
                var x = line.Split("/").Select(x => int.Parse(x)).ToArray();
                Console.WriteLine(FractionToDirection(new Fraction(x[0],x[1])));
            } else {
                Console.WriteLine(DirectionToFraction(line));
            }
        }

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");
      
    }
}