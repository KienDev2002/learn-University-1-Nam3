
import queue

res = []
d = 1
def sol(n,m,A):
    global d,res
    for i in range(1,n+1):
        for j in range(1,m+1):
            if A[i][j]==0:
                Q = queue.LifoQueue()
                d = 1
                DFS(i,j,A,Q)
                res.append(d)
    res.sort()
    print(len(res))
    print(*res,sep="\t")

def DFS(u,v,A,Q):
    global d
    A[u][v] = 1
    Q.put((u,v))
    while Q.qsize():
        x,y = Q.get()
        for i in [-1,0,1]:
            for j in [-1,0,1]:
                if A[x+i][y+j]==0:
                    d+=1
                    DFS(x+i,y+j,A,Q)




if __name__ == '__main__':
    n,m= map(int,input().split())
    A =[[1] * (m+2)]
    for i in range(n):
        z = list(map(int,input().split()))
        A.append([1] + z + [1])
    A.append([1] * (m+2))
    sol(n,m,A)