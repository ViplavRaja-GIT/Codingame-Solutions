#Link=> "https://www.codingame.com/training/easy/benfords-law"

import sys
import math

n = int(input())
d={1:0,2:0,3:0,4:0,5:0,6:0,7:0,8:0,9:0}
s={1:0,2:0,3:0,4:0,5:0,6:0,7:0,8:0,9:0}
ch = { 1: [20.1,40.1], 2: [7.6,27.6], 3: [2.5,22.5], 4: [-0.3,19.7], 5: [-2.1,17.9], 6: [-3.3,16.7], 7: [-4.2,15.8], 8: [-4.9,15.1], 9: [-5.4,14.6] }
r=[]
for i in range(n):
    m = input()
    q=''
    for i in m:
        if i.isdigit():
            q+=i
    q.replace(',','')
    t = str(abs(float(q)))
    r.append(t)

for i in r:
    if i.startswith('1'):
        d[1]+=1
    if i.startswith('2'):
        d[2]+=1
    if i.startswith('3'):
        d[3]+=1
    if i.startswith('4'):
        d[4]+=1
    if i.startswith('5'):
        d[5]+=1
    if i.startswith('6'):
        d[6]+=1
    if i.startswith('7'):
        d[7]+=1
    if i.startswith('8'):
        d[8]+=1
    if i.startswith('9'):
        d[9]+=1
k=1
for i,j in d.items():
    s[k] = (round(j/len(r),2))*100
    k+=1


b = False
for i in range(1,len(s)+1):
    if s[i] >= ch[i][0] and s[i] <= ch[i][1]:
        b = False
    else:
        b = True
        break

print('true') if b else print('false')


# To debug: print("Debug messages...", file=sys.stderr, flush=True)

