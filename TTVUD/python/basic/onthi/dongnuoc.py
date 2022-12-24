# đong nước
# tuble vs list''''''''





import queue

P = {}
count = 0

def BFS(n,m,k):
    global P
    global count
    Q = queue.Queue()
    Q.put((0,0))
    P[(0,0)] = (-1,-1)
    while Q.qsize():
        x,y= Q.get()
        Next = [(x,0),(0,y),(n,y),(x,m),(max(0,x+y-m),min(x+y,m)), (min(x+y,n),max(0,x+y-n))]
        for v in Next:
            if v not in P.keys():
                Q.put(v)
                P[v] = (x,y)
                if v[0]==k or v[1]==k:
                    while P[v] != (-1,-1):
                        count +=1
                        v = P[v]
                    print(count)
                    return

    print("Khong dong duoc nuoc")

if __name__ == '__main__':
    n, m, k = list(map(int,input().split()))
    BFS(n,m,k)

"3 4 2"

























'''
# ĐOng nước :
from collections import namedtuple
from queue import  *




class Water:
    P = {} #mảng cha để xem tt nào sinh ra tt nào.
    count = 0
    def input(self):
        self.n ,self.m,self.k = list(map(int,input().split(' ')))
    def inkq(self,v):
        if v[0] == v[1]==0: print(self.count)
        else:
            self.count += 1
            self.inkq(self.P[v])


    def BFS(self):
        Q = Queue()
        Q.put((0,0)) #put tuple vào
        self.P[(0,0)] = (-1,-1) # cha của P là -1 -1
        while(Q.qsize()):
            x,y = Q.get()
            z = x + y
            Next = [(0,y),(x,0),(self.n,y),(x,self.m),(max(0,z-self.m), min(z,self.m)),(min(z,self.n),max(0,z - self.n))]
            for v in Next:
                if v not in self.P.keys():
                    Q.put(v)
                    self.P[v] = (x,y) #P[v] là con của (x,y)
                    if v[0]==self.k or v[1]==self.k:
                        self.inkq(v)
                        return
        print("Khong dong duoc nuoc")

if __name__ == '__main__':
    W = Water()
    W.input()
    W.BFS()'''