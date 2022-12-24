

import queue

res = []


def sol(n, m, A):
    global res
    for i in range(1, n + 1):
        for j in range(1, m + 1):
            if A[i][j] == 0:
                BFS(i, j)
    res.sort()
    print(len(res))
    print(*res)


def BFS(u, v):
    global res
    d = 1
    A[u][v] = 1
    Q = queue.Queue()
    Q.put((u, v))
    while Q.qsize():
        x, y = Q.get()
        for i in [-1, 0, 1]:
            for j in [-1, 0, 1]:
                if (A[x + i][y + j] == 0):
                    Q.put((x + i, y + j))
                    A[x + i][y + j] = 1
                    d += 1
    res.append(d)


if __name__ == '__main__':
    n, m = map(int, input().split())
    A = [[1] * (m + 2)]
    for i in range(n):
        a = list(map(int, input().split()))
        A.append([1] + a + [1])
    A.append([1] * (m + 2))
    sol(n,m,A)


'''
6 5
1   1   1   1   1   
1   1   1   1   0   
0   1   1   0   0  
0   1   1   0   1   
1   0   1   1   1   
1   1   1   1   1   
'''















'''

import queue

# 25 cột 26 dòng
# 23 cột 24 dòng

class Image:
    res = []#res lưu các số chữ số 0 trong từng vùng
    def nhap(self):
        self.n,self.m = map(int,input().split())
        self.A = [[1]*(self.m+2)] #[[1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1]] thêm vào đầu trên
        for i in range(self.n):
            z = list(map(int,input().split()))
            self.A.append([1] + z + [1]) # thêm 2 cột 1 ở đầu, cuối hàng để thành 25 cột
        self.A.append(([1] * (self.m + 2))) #[[1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1]] thêm vào đầu dưới


    def xuat(self):
        for a in self.A:
            print(*a)


    def sol(self):
        for i in range(1,self.n + 1):
            for j in range(1,self.m + 1):
                if self.A[i][j] == 0:
                    self.BFS(i,j)
        self.res.sort()
        print(len(self.res)) #show ra độ dài của res là số vùng có chữ số 0
        print(*self.res) #show ra từng ptu trong mảng res là từng số chữ 0 trong từng vùng

    # u là hàng thứ i, v là cột thứ j mà a[i][j] = 0
    def BFS(self,u,v):
        d  = 1
        self.A[u][v] = 1 # đánh dấu đã đi qua
        Q = queue.Queue()
        Q.put((u,v)) # put hàng i cột j (i,j) mà a[i][j] = 0 vào trong queue.
        while Q.qsize():
            x,y = Q.get()
            print("get(%d,%d)"%(x,y))
            for i in [-1,0,1]: # duyệt 2 vòng để tìm xem xung quanh nó có thằng nào bằng 0 ko
                for j in [-1,0,1]:
                    if self.A[x+i][y+j]==0: #nếu có đứa = 0 thì put vào Q ....
                        print("self.A[%d][%d] = %d" %(x+i,y+j,self.A[x+i][y+j]))
                        Q.put((x+i,y+j))
                        self.A[x+i][y+j] = 1 #đánh dấu là đã xét
                        d+=1
                        print("d = %d" %d)
        self.res.append(d)
if __name__ == '__main__':
    I = Image()
    I.nhap()
    I.sol()
'''
