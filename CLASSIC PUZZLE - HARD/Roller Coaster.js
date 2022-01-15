// https://www.codingame.com/ide/puzzle/roller-coaster
/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/

 var inputs = readline().split(' ');
 let L = parseInt(inputs[0]);
 let C = parseInt(inputs[1]);
 let N = parseInt(inputs[2]);
 const groups = [];
 for (let i = 0; i < N; i++) {
     const pi = parseInt(readline());
     groups.push(pi);
 }
 
 let dhiram = 0;
 let end = groups.length;
 let index = 0;
 let sumArr = 0;
 let reset = groups.length;
 while( C > 0 ){
     sumArr = 0;
     while(sumArr+groups[index] <= L && index < end){
         sumArr += groups[index++];
         if(index == reset) break;
         index == end && (index = 0);
     }
     reset = index;
     index == end && (index=0)
     dhiram += sumArr == 0 ? L : sumArr;
     C--;
 }
 console.log(dhiram);