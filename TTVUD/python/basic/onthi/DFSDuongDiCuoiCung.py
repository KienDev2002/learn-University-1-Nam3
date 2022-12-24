import math
import queue

d = [0] * 10000
check = True

def dfs(m, n, stack):
    global check
    stack.put(m)
    d[m] = 1
    for i in range(int(math.sqrt(m)) + 1, 0, -1):
        if check:
            if m % i == 0:
                v = (i - 1) * (m // i + 1)
                if v >= n and d[v] == 0:
                    dfs(v, n, stack)
                if v == n:
                    out = []
                    while stack.qsize():
                        out.append(stack.get())
                    print(*out[::-1], sep=" ")
                    check = False
                    return


if __name__ == '__main__':
    m, n = map(int, input().split())
    stack = queue.LifoQueue()
    dfs(m,n, stack)
    if check:
        print("Khong Sinh Ra Duoc")



'''

import math
import queue

d=[0]*(10005)
def inkq(d,n,m):
    if n==m: return [m]
    return inkq(d,n,d[m])+[m]
def DFS(n,m):
    kt = 0
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
                    kt =1
                    print(*inkq(d,n,m),sep=" ")
                    return
    if m==0:
        print(*inkq(d, n, m), sep=" ")
        return
    print("Khong Sinh Ra Duoc")
if __name__ == '__main__':
    n,m = map(int,input().split())
    DFS(n,m)
'''