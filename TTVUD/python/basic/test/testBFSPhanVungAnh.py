
'''
6 5
1   1   1   1   1
1   1   1   1   0
0   1   1   0   0
0   1   1   0   1
1   0   1   1   1
1   1   1   1   1
'''
import queue

res = []
def sol(n,m,A):
    for i in range(1,n+1):
        for j in range(1,m+1):
            if A[i][j]==0:
                BFS(i,j)
    res.sort()
    print(len(res))
    print(*res, sep="\t")


def BFS(u,v):
    Q = queue.Queue()
    Q.put((u,v))
    A[u][v] = 1
    d = 1
    while Q.qsize():
        x,y = Q.get()
        for i in [-1,0,1]:
            for j in [-1,0,1]:
                if A[x+i][y+j]==0:
                    A[x+i][y+j] = 1
                    Q.put((x+i,y+j))
                    d+=1
    res.append(d)

if __name__ == '__main__':
    n,m= map(int,input().split())
    A = [[1] * (m+2)]
    for i in range(n):
        z = list(map(int,input().split()))
        A.append([1] + z + [1])
    A.append([1] * (m + 2))
    sol(n,m,A)