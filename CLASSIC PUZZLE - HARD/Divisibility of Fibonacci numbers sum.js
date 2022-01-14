//codingame.com/ide/puzzle/divisibility-of-fibonacci-numbers-sum

function febo(n , mod){
    if(n <= 1)
        return {f_half_1: Math.abs(n-1), f_half : n};
    const {f_half_1, f_half} = febo(parseInt(n/2), mod);
    var f_2n_1 = 0;
    var f_2n = 0;
    if(n%2 == 0){
        f_2n_1 = f_half**2 % mod + f_half_1**2 % mod
        f_2n = ((2 * f_half_1 % mod + f_half) % mod) * f_half
    } else{
        f_2n_1 = ((2 * f_half_1 % mod + f_half) % mod) * f_half
        f_2n = (((f_half + f_half_1) % mod)**2 % mod) + (f_half**2 % mod)
    }
    return {f_half_1: f_2n_1 % mod, f_half : f_2n % mod};
}
 

const nb = parseInt(readline());
for (let i = 0; i < nb; i++) {
    var inputs = readline().split(' ');
    const a = parseInt(inputs[0]);
    const b = parseInt(inputs[1]);
    const d = parseInt(inputs[2]);

    let {f_half_1, f_half} = febo(a,d);
    let S = f_half;
    for(let j=a+1; j<=b; j++){
        [f_half_1, f_half] = [f_half, (f_half+f_half_1)%d]
        S = (S + f_half) %d;
    }
    
    console.log("F_"+a+" + ... + F_"+b+" is "+ (S>0 ? "NOT ":"") +"divisible by "+d);
}
