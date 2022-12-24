


import queue

res = []
d = 1

def sol(n, m, A):
    global res
    global d
    for i in range(1, n + 1):
        for j in range(1, m + 1):
            if A[i][j] == 0:
                d = 1
                Q = queue.LifoQueue()
                DFS(i, j,Q)
                res.append(d)
    res.sort()
    print(len(res))
    print(*res)


def DFS(u, v,Q):
    global d
    Q.put((u, v))
    A[u][v] = 1
    while Q.qsize():
        x,y = Q.get()
        for i in [-1, 0, 1]:
            for j in [-1, 0, 1]:
                if (A[x + i][y + j] == 0):
                    d += 1
                    DFS(x+i,y+j,Q)



if __name__ == '__main__':
    n, m = map(int, input().split())
    A = [[1] * (m + 2)]
    for i in range(n):
        a = list(map(int, input().split()))
        A.append([1] + a + [1])
    A.append([1] * (m + 2))
    sol(n,m,A)


'''
6 5
1   1   1   1   1   
1   1   1   1   0   
0   1   1   0   0  
0   1   1   0   1   
1   0   1   1   1   
1   1   1   1   1   
'''







