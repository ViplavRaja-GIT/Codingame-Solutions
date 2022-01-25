#Link-> https://www.codingame.com/ide/puzzle/length-of-syracuse-conjecture-sequence

import sys
import math

def collatzLenUtil(n, collLenMap):
     
    if n in collLenMap:
        return collLenMap[n]
     
    if(n == 1):
        collLenMap[n] = 1
 
    elif(n % 2 == 0):
        collLenMap[n] = 1 + collatzLenUtil(n/2, collLenMap)
 
    else:
        collLenMap[n] = 1 + collatzLenUtil(3 * n + 1, collLenMap)
     
    return collLenMap[n]
 
def collatzLen(m,n):
    collLenMap = {}
    collatzLenUtil(n, collLenMap)
 
    num, l =-1, 0
     
    for i in range(m, n):
         
        if i not in collLenMap:
            collatzLenUtil(i, collLenMap)
         
        cLen = collLenMap[i]
        if l < cLen:
            l = cLen
            num = i
     
    return num, l

l=[]
n = int(input())
a,b=0,0

for i in range(n):
    a, b = [int(j) for j in input().split()]
    m,p = collatzLen(a,b)
    print(m,p)    
