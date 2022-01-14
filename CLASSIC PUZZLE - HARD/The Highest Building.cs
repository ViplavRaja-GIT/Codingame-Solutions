// https://www.codingame.com/ide/puzzle/the-highest-building
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
    //Calculate Building Length
    static int BuildingLength(List<string> building){
        int len = 0;
        foreach (var item in building)
        {
            if(item.Trim().Length > len){
                len = item.Trim().Length;
            }
        }
        return len;
    }

    static void PrintBuilding(List<string> building, int len){
        for(int l=0; l<len; l++){
            var x = string.Join("" , building.Select(x=> x[l]));
            if(x.Trim() != "")
               Console.WriteLine(x.TrimEnd());
        }
    }

    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int W = int.Parse(inputs[0]);
        int H = int.Parse(inputs[1]);
        List<string> verticalBuildings = new List<string>();
        for (int i = 0; i < H; i++)
        {
            verticalBuildings.Add(Console.ReadLine());
        }
        
        bool building = false;
        List<List<string>> rotatedBuildings = new List<List<string>>();
        List<string> refrence = null; //New Building Start Refrence
        for(int j = 0; j < W; j++){
            string str = string.Join("", verticalBuildings.Select(x => x[j]));
            if(str.Trim() != ""){
                if(!building){
                    building = true;
                    refrence = new List<string>();
                    rotatedBuildings.Add(refrence);
                }
                refrence.Add(str);
            } else {
                building = false;
            }
        }
        rotatedBuildings = rotatedBuildings.OrderBy(x => BuildingLength(x)).ToList();
        int lenCriteria = BuildingLength(rotatedBuildings[rotatedBuildings.Count()-1]);
        rotatedBuildings = rotatedBuildings.Where(x => lenCriteria == BuildingLength(x)).ToList();
        for (int z=0; z < rotatedBuildings.Count(); z++)
        {
            PrintBuilding(rotatedBuildings[z], H);
            if(z != rotatedBuildings.Count()-1)
                Console.WriteLine("");
        }
    }
}