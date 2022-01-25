#Link -> https://www.codingame.com/training/easy/the-mystic-rectangle

import sys
import math

x, y = [int(i) for i in input().split()]
u, v = [int(i) for i in input().split()]
dx = min((200+(x-u)%200)%200,(200+(u-x)%200)%200)
dy = min((150+(y-v)%150)%150,(150+(v-y)%150)%150)

print(round(dx*.3 + dy*.4 - min(dx,dy)*.2 , 2))
