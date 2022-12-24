
import  queue
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
            d,u = Q.get() #d là độ dài cạnh, u là đỉnh di.
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