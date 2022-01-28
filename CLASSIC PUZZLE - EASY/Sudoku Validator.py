#https://www.codingame.com/ide/puzzle/sudoku-validator

import sys
import math
import copy

def validator(listRow):
    for row in listRow:
        if len(row) != len(list(set(row.copy()))):
           return False
    return True

l =[]
nl=[]

for i in range(9):
    m=[]
    for j in input().split():
        n = int(j)
        m.append(n)
    l.append(m)
b = validator(l)

# Write an answer using print
# To debug: print("Debug messages...", file=sys.stderr, flush=True)
t = [[l[j][i] for j in range(len(l))] for i in range(len(l[0]))]
bt = validator(t)

nl = copy.deepcopy(l)

x,y=0,0
for a in range(9):    
    i=0
    k=0
    while i<3:
        j=0
        while j<3:
            nl[a][k] = l[x+i][y+j]
            j+=1
            k+=1
        i+=1
    x+=3
    k=0
    if x>=9:
        x=0
        y+=3
bg = validator(nl)

print("b-->",b, file=sys.stderr, flush=True)
print("bt-->",bt, file=sys.stderr, flush=True)
print("bg-->",bg, file=sys.stderr, flush=True)

if b and bt and bg:
    print("true")
else:
    print("false")