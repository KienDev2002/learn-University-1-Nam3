

F = [0] * 10001
def root(x):
    global F
    return x if F[x]==0 else root(F[x])



def sol():
    global F
    n,m = map(int,input().split())
    A = []
    for i in range(m):
        u,v,w = map(int,input().split())
        A.append((u,v,w))
    A.sort(key= lambda x: x[2])
    res = 0
    for u,v,w in A:
        x = root(u)
        y = root(v)
        if x!=y:

            while u != x:
                z = F[u]
                F[u] = x
                u = z

            while v!=y:
                z = F[v]
                F[v] = x
                v = z

            F[y] = x
            res+=w
    print(res)

if __name__ == '__main__':
    sol()









