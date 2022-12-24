

import queue

d = {}

def sol(n,m,k):
    Q = queue.Queue()
    res = 0
    Q.put((0,0))
    d[(0,0)] = (-1,-1)
    while Q.qsize():
        x,y = Q.get()
        Next = [(x,0),(0,y),(x,m),(n,y),(max(0,x+y-m),min(x+y,m)),(min(x+y,n),max(0,x+y-n))]
        for v in Next:
            if v not in d.keys():
                d[v] = (x,y)
                Q.put(v)
                if v[0]==k or v[1]==k:
                    while d[v] != (-1,-1):
                        res+=1
                        v = d[v]
                    print(res)
                    return
    print("Khong dong duoc nuoc")

if __name__ == '__main__':
    n,m,k = map(int,input().split())
    sol(n,m,k)