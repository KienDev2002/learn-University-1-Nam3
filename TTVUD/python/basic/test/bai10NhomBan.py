



F=[0]*100005
D=[1]*100005
def root(x):
    global F
    return x if F[x]==0 else root(F[x])

def sol():
    global F,D
    n, m = map(int, input().split())
    g = n
    res = 0
    while m!=0:
        u,v = map(int,input().split()) # u:3, v:4
        x = root(u) #4
        y = root(v) #4
        if x!=y:

            while u!=x:
                z = F[u]
                F[u] = x
                u = z

            while v != y:
                z = F[v] # z= 3
                F[v] = x
                v = z # v=3
            g-=1
            F[y] = x
            D[x] +=D[y]
            if res<D[x]:
                res=D[x]
        m-=1

    print(g,res,sep="\n")

if __name__ == '__main__':
    sol()
'''10 4
8 9
3 5 
4 5
3 4


'''