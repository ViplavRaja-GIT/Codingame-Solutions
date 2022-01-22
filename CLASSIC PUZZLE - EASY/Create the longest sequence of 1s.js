// https://www.codingame.com/ide/puzzle/create-the-longest-sequence-of-1s
/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/

 const b = readline();
 const zeroIndexs = [];
 b.split('').forEach((v,i) => (v == '0') && zeroIndexs.push(i));
 
 let max = 0;
 for(var index of zeroIndexs){
     let modifiedString = b.split('');
     modifiedString[index] = "1";
     modifiedString.join('').split('0').forEach(x => {
         if(x.length > max){
             max = x.length;
         }
     });
 }
 console.error(zeroIndexs);
 console.log(max);