

#đếm số cặp nghịch thế

#4 7 2 8 9 1 6 3 5
'''
A = [0] * 400005
res = 0
def update(k,L,R,x):
    global A
    global res
    A[k]+=1
    if L==R: return
    if x <= (L + R) // 2:
        res += A[2 * k + 2]
        update(2 * k + 1, L, (L + R) // 2, x)
    else:
        update(2 * k + 2, (L + R) // 2 + 1, R, x)


if __name__ == '__main__':
    n = int(input())
    for x in map(int, input().split()):
        update(0,1,n,x)
    print(res)




class node:
    def __init__(self,a,b):
        self.elem = 0
        self.end = b
        if a == b:
            self.left, self.right = None, None
        else:
            self.left = node(a, (a + b) // 2)
            self.right = node((a + b) // 2 + 1, b)

res = 0
def update(H,x):
    global res
    H.elem += 1
    if H.left!=None:
        if x <= H.left.end:
            res += H.right.elem
            update(H.left,x)
        else:
            update(H.right,x)

if __name__ == '__main__':
    n = int(input())
    H = node(1,n)
    for x in map(int, input().split()):
        update(H,x)
    print(res)
'''




# DSI: nhóm bạn
class Graph:
    def __init__(self):
        self.F = [0] * 100005
        self.res = 0
    def root(self, x):
        return x if self.F[x] == 0 else self.root(self.F[x])
    def sol(self):
        self.n, self.m = map(int, input().split())
        self.D = [1] * 100005
        self.g = self.n
        while(self.m != 0):
            u,v = map(int, input().split())
            x = self.root(u)
            y = self.root(v)
            if x != y:
                while(u!=x):
                    z = self.F[u]
                    self.F[u] = x
                    u = z
                while (v != y):
                    z = self.F[v]
                    self.F[v] = x
                    v = z
                self.g-=1
                self.F[y]=x
                self.D[x]+=self.D[y]
                if self.res <self.D[x]:
                    self.res = self.D[x]
            self.m -= 1
        print(self.g)
        print(self.res)
if __name__ == '__main__':
    G =Graph()
    G.sol()