#Link:- https://www.codingame.com/training/easy/van-ecks-sequence

import sys
import math

a1 = int(input())
n = int(input())
dt=[-1]*n
sq=[0]*n
sq[0] = a1
for i in range(n-1):
    if(dt[sq[i]] >= 0):
        sq[i+1] = i-dt[sq[i]]
    dt[sq[i]] = i
print(sq[n-1])
