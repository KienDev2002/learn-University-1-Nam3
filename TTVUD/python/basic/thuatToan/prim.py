
# Prim
import queue
class Graph:
    def nhap(self):
        self.n, self.m = map(int,(input().split()))
        self.A = [[] for i in range(self.n+1)]
        for i in range(self.m):
            u,v,w = map(int,input().split())
            self.A[u].append((w,v)) #2 chieu vo huong
            self.A[v].append((w,u)) #2 chieu vo huong

    def Prim(self):
        Q = queue.PriorityQueue()
        Q.put((0,1))
        L = [0,0] + [1e9] * (self.n+2) #2 cái đầu 0
        s = 0
        P = [0] * (self.n+2)
        while Q.qsize():
            d,u = Q.get()
            if L[u] < d: continue
            s+=L[u]
            L[u] = -1 #danh dau da xet sang -1
            for z,v in self.A[u]:
                if L[v] >  z:
                    L[v] = z
                    P[v] = u
                    Q.put((z,v))

        print(s)
        for i in range(2,self.n + 1):
            print("chon canh %d %d" % (P[i], i))

if __name__ == '__main__':
    G = Graph()
    G.nhap()
    G.Prim()


