
#đong nước
#tuble vs list
import queue
class water:
    P = {} # mảng cha(trạng thái nào do trạng thái nào sinh ra)
    count=0
    def nhap(self):
        self.n, self.m, self.k=map(int,input().split())
    def inkq(self,v):
        if v[0]==v[1]==0:
            #print("0,0", end="")
            print(self.count)
        else:
            self.count += 1
            self.inkq(self.P[v])
            #print("->(%d,%d)"%(v[0],v[1]),end="")

    def BFS(self):
        Q = queue.Queue()
        Q.put((0,0))
        self.P[(0,0)] = (-1,-1)
        while Q.qsize():
            x,y = Q.get()
            z = x+y
            Next=[(0,y),(x,0),(self.n,y),(x,self.m),(max(0,x+y-self.m),min(x+y,self.m)),(min(self.n,x+y),max(0,x+y-self.n))]
            for v in Next:
                if v not in self.P.keys():
                    Q.put(v)
                    self.P[v] = (x,y)
                    if v[0]==self.k or v[1]==self.k:
                        i, j = v[0], v[1]
                        while self.P[v] != (-1,-1):
                            self.count += 1
                            v = self.P[v]
                        print(self.count)
                        #self.inkq(v)
                        return
        print("Khong dong duoc nuoc")

if __name__ == '__main__':

    w = water()
    w.nhap()
    w.BFS()
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