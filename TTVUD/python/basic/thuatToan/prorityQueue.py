






# hafng dọi ưu tiên ngược lại
from queue import *
Q = PriorityQueue()
for x in [4,6,7,4,3,3,7]: Q.put(-x)
while Q.qsize():
    print(-Q.get(),end=" ")