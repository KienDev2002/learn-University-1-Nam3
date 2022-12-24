
import math
import queue

d=[0]*(10005)
def inkq(d,n,m):
    if n==m: return [m]
    return inkq(d,n,d[m])+[m]
def DFS(n,m):
    q = queue.LifoQueue()
    q.put(n)
    while q.qsize():
        u = q.get()
        for i in range(1,int(math.sqrt(u)+1)):
            if u % i == 0:
                v = (i - 1) * (u // i + 1)
                if v>=m and (d[v] == 0 or d[v]>=u):
                    d[v] = u
                    q.put(v)
                if v==m and m!=0:
                    print(*inkq(d,n,m),sep=" ")
                    return
    if m==n:
        print(*inkq(d, n, m), sep=" ")
        return
    print("Khong Sinh Ra Duoc")
if __name__ == '__main__':
    n,m = map(int,input().split())
    DFS(n,m)