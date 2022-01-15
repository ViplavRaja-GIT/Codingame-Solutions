// https://www.codingame.com/training/hard/kolakoski-sequence/solution
/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/

 const N = parseInt(readline());
 var inputs = readline().split(' ');
 const A = parseInt(inputs[0]);
 const B = parseInt(inputs[1]);
 
 let values = [A,B];
 let result = "";
 let index = 0;
 let runLength = values[0];
 
 while(index < N){
     for(let i=0; i < runLength; i++){
         result += values[index%2].toString();
         if(result.length >= N)
         {
             console.log(result);
             return;
         }
     }
     index++;
     if(index == result.length){
         result += values[index%2].toString();
         runLength = values[index%2] - 1;
     } else {
         runLength = parseInt(result[index]);
     }
 }