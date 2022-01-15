//https://www.codingame.com/ide/puzzle/disks-intersection
const dis = (x1,y1,x2,y2) => Math.sqrt((x2-x1)**2 + (y2-y1)**2);  

const intersectionArea = (A,B) => {
    let d = dis(A.x,A.y,B.x,B.y);
    if(d < A.r+B.r) {
        let a = A.r * A.r;
        let b = B.r * B.r;
        let x = ((a-b)+(d*d))/(2*d);
        let y = Math.sqrt(a- (x*x));
        if(isNaN(y)){
            return Math.PI * Math.min(a,b);
        } else {
            return a * Math.asin(y/A.r) + b * Math.asin(y/B.r) - x * y - Math.sqrt((b-a)+(x*x)) * y;
        }
    }
    return 0;
}

var inputs = readline().split(' ');
const A = {};
A.x = parseInt(inputs[0]);
A.y = parseInt(inputs[1]);
A.r = parseInt(inputs[2]);
var inputs = readline().split(' ');
const B = {};
B.x = parseInt(inputs[0]);
B.y = parseInt(inputs[1]);
B.r = parseInt(inputs[2]);

var res = intersectionArea(A,B);
console.log(Number(res).toFixed(2));
