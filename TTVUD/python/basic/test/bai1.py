

import queue
import math

d = [0] * 10005
def BFS(n):
    global d
    A = []
    Q = queue.Queue()
    Q.put(n)
    d[n] = 1
    while Q.qsize():
        u = Q.get()
        for i in range(1,int(math.sqrt(u))+1):
            if u%i==0:
                v = (i-1) * (u//i +1)
                if d[v]==0:
                    Q.put(v)
                    d[v] = 1

    for i in range(len(d)):
        if d[i]==1:
            A.append(i)
    print(*A, sep="\t")


if __name__ == '__main__':
    n = int(input())
    BFS(n)

    # 18