// https://www.codingame.com/ide/puzzle/egyptian-multiplication
/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
 const printLine = (n, m, r, sign = true) => {
    let rem = `${n} * ${m}`;
    if (r.length > 0) {
        rem += ` + ${r.join(" + ")}`
    }
    console.log(sign ? `= ${rem}` : rem);
}

var inputs = readline().split(' ');
const a = parseInt(inputs[0]);
const b = parseInt(inputs[1]);

let number = a < b ? b : a;
let multiplier = a < b ? a : b;
let remaining = [];

printLine(number, multiplier, remaining, false);

while (multiplier !== 0) {
    if(multiplier%2 === 1){
        remaining.push(number);
        multiplier-=1;
    } else {
        number *= 2;
        multiplier /= 2;
    }
    printLine(number, multiplier, remaining);
}

console.log(`= ${(a*b)}`);