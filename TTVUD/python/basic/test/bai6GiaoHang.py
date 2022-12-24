


import queue


if __name__ == '__main__':
    n = int(input())
    A = [[] for i in range(n+5)]
    for i in range(n):
        t,v = map(int,input().split())
        A[t].append(v)
    PQ = queue.PriorityQueue()
    res = 0
    for i in range(n,0,-1):
        for x in A[i]:
            PQ.put(-x)
        if PQ.qsize():
           res+=PQ.get(x)
    print(-res)

