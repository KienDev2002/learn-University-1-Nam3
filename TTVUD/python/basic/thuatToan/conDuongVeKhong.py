

# mọi con đường về không

import math
import queue
A = []
def bfs(n):
    global A
    Q = queue.Queue()
    d = [0] * (n + 5) #mang danh dau toan 0
    Q.put(n)
    d[n] = 1 #dánh dấu đã đi qua.
    while(Q.qsize()):
        u = Q.get()
        for i in range(1, int(math.sqrt(u) + 1)):
            if u % i ==0:
                v = (i-1) * (u//i + 1)
                if d[v]==0:
                    Q.put(v)
                    d[v] = 1

    for i in range (n+1):
        if d[i]==1:
            A.append(i)

if __name__ == '__main__':
    n = int(input())
    bfs(n)
    print(*A,sep="\t")
