import queue


class Image:
    res = []
    def nhap(self):
        self.n,self.m = map(int,input().split())
        self.A = [[1]*(self.m+2)]
        for i in range(self.n):
            z = list(map(int,input().split()))
            self.A.append([1]+z+[1])
        self.A.append(([1] * (self.m + 2)))


    def xuat(self):
        for a in self.A:
            print(*a)


    def sol(self):
        for i in range(1,self.n + 1):
            for j in range(1,self.m + 1):
                if self.A[i][j] == 0:
                    self.BFS(i,j)
        self.res.sort()
        print(len(self.res))
        print(*self.res)

    def BFS(self,u,v):
        d  = 1
        self.A[u][v] = 1 # đã đi qua
        Q = queue.Queue()
        Q.put((u,v)) #mỗi tt là cặp u,v
        while Q.qsize():
            x,y = Q.get()
            for i in [-1,0,1]: # duyệt 2 vòng lặp 9 ô gồm nó và 8 láng giềng
                for j in [-1,0,1]:
                    if self.A[x+i][y+j]==0:

                        Q.put((x+i,y+j))
                        self.A[x+i][y+j] = 1
                        d+=1
        self.res.append(d)
if __name__ == '__main__':
    I = Image()
    I.nhap()
    I.xuat()
    I.sol()

