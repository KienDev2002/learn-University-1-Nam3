
import queue
import math

d = [0] * 10005
def DFS(n,S):
    for i in range(1, int(math.sqrt(n) +1 )):
        if n % i == 0:
            v = (i-1) * (n//i + 1)
            if d[v]==0:
                d[v] = 1
                S.put(v)
                DFS(v,S)

if __name__ == '__main__':
    n = int(input())
    S = queue.LifoQueue()
    d[n] = 1
    S.put(n)
    DFS(n,S)
    for i in range(n+1):
        if d[i]==1:
            print(i,end="\t")