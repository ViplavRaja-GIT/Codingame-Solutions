// https://www.codingame.com/training/easy/sum-of-spirals-diagonals
/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/

 let n = parseInt(readline());
 let d = n-1;
 let last  = 1
 let res = [last];
 while(d >= 1){
     for(let i = 0; i< 4 ; i++){
         if(last+d <= n**2){
             res.push(last+d);
             last = last+d;
         }
     }
     d = d-2;
 }
 console.log(res.reduce((a,b) => a+b));
 