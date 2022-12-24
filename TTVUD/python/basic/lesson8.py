import queue



# chinh thám
'''
Q =  queue.PriorityQueue()
n = int(input("Nhập n:"))
k = int(input("Nhập k:"))
for i,x in enumerate(map(int,input().split()),1): #chỉ số từ 1
    Q.put((-x,i))
    if i >= k:
        while i - Q.queue[0][1] >=k:
            Q.get()
        print(-Q.queue[0][0], end="")    
'''



# djicktra
'''
    class Graph:
    def nhap(self, fname):
        f = open(fname)
        self.n, self.m = map(int,(f.readline().split()))
        self.A = [[] for i in range(self.n+1)]
        for i in range(self.m):
            u,v,w = map(int,f.readline().split())
            self.A[u].append((w,v))
        f.close()
        print(self.A)
    def inkq(self,s,v):
        if (s==v):
            print(s,end="")
        else:
            self.inkq(s,self.P[v])
            print("-> %d"%v , end="")
    def Dijkstra(self,s): #tim duong di ngan nhat tu s den cac dinh
        Q = queue.PriorityQueue()
        Q.put((0,s))
        L = [1e9] * (self.n+2)
        self.P = [-1] * (self.n + 2) # lưu cha
        L[s] = 0
        while Q.qsize():
            d,u = Q.get()
            if(L[u] < d): continue
            for z,v in self.A[u]:
                if(L[v] > d + z):
                    L[v] = d+z
                    self.P[v] = u
                    Q.put((d+z,v))
        for i in range(1,self.n+1):
            print("\nddnn tu %d den %d la %d"%(s,i,L[i]))
            self.inkq(s,i)

if __name__ == '__main__':
    G = Graph()
    G.nhap('djicktra.txt')
    G.Dijkstra(3)

'''


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

    def Prim(self): #tim duong di ngan nhat tu s den cac dinh
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


