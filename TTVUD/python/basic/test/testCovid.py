

import queue

if __name__ == '__main__':
    n,m = map(int,input().split())
    tiepxuc = [[] for i in range(n+5)]
    check_F = [-1] * (n+5)
    F = [0] * 10005
    for i in range(m):
        u,v = map(int,input().split())
        tiepxuc[u].append(v)
        tiepxuc[v].append(u)
    F[0] = int(input())
    Q = queue.Queue()

    for x in list(map(int,input().split())):
        Q.put(x)
        check_F[x]=0
    while Q.qsize():
        x = Q.get()
        for v in tiepxuc[x]:
            if check_F[v] == -1:
                check_F[v] =check_F[x] + 1
                Q.put(v)
                F[check_F[v]]+=1

    i = 0
    while F[i]:
        print("F%d: %d" % (i, F[i]))
        i += 1