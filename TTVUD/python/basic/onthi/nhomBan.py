


F=[0]*100005
D=[1]*100005
def root(x):
    global F
    return x if F[x]==0 else root(F[x])
def sol():
    global F,D
    n,m=map(int,input().split())
    g=n
    res=0
    while (m != 0):
        u,v=map(int,input().split())
        x,y=root(u),root(v)
        if x!=y:
            while u!=x:
                z=F[u]
                F[u]=x
                u=z
            while v!=y:
                z=F[v]
                F[v]=x
                v=z
            g -= 1
            F[y]=x
            D[x]+=D[y]
            if res<D[x]:
                res=D[x]
        m-=1
    print(g,res,sep="\n")
if __name__ == '__main__':
    sol()



'''
10 4
8 9
3 5 
4 5
3 4
'''



'''
# DSI: nhóm bạn
class Graph:
    def __init__(self):
        self.F = [0] * 100005 #mang có 1000005 số 0.để lưu trữ xem cha của nó là ai.
        self.res = 0 # res = 0 là số người của khu vực đông nhất, show ra kq

    def root(self, x):
        return x if self.F[x] == 0 else self.root(self.F[x])

    def sol(self):
        self.n, self.m = map(int, input().split()) #n là số sv, m là số mối qh
        self.D = [1] * 100005 #mang có 1000005 số 1
        self.g = self.n # g la so khu mực cần đc bố trí
        while(self.m != 0): #nếu còn có mối qh m > 0
            u,v = map(int, input().split()) #lấy u,v là 2 mối quan hệ với nhau

            x = self.root(u)
            print("x: %d" %x)

            y = self.root(v)
            print("y: %d" %y)

            if x != y:
                while(u!=x):
                    z = self.F[u]
                    self.F[u] = x
                    print("F[%d]: %d" % (u, self.F[u]))
                    u = z
                    print("z: %d" %z)
                while (v != y):
                    z = self.F[v]
                    self.F[v] = x
                    print("F[%d]: %d" % (v, self.F[v]))
                    v = z
                    print("z: %d" %z)

                self.g-=1
                print("g: %d" %self.g)

                self.F[y]=x
                print("F[%d]: %d" %(y,self.F[y]))



                print("D[%d]: %d" %(x ,self.D[x]))
                print("D[%d]: %d" % (y , self.D[y]))
                self.D[x]+=self.D[y]
                print("D[%d]: %d" %(x ,self.D[x]))

                if self.res <self.D[x]: # nếu khu vực nào lớn D[x] cua Khu vực ý thì res sẽ thay thế là D có khu vực lớn hơn
                    self.res = self.D[x] #là số người của khu vực đông nhất,
                    print("res: %d" %self.res)
            self.m -= 1
        print(self.g)
        print(self.res)
if __name__ == '__main__':
    G =Graph()
    G.sol()'''