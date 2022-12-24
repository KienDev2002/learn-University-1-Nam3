


#thuật toán Kruskal
F = [0] * 10001
#cho bt xem gốc ở đâu
def root(x):
    return x if F[x]==0 else root(F[x])


def sol():
    n, m = map(int, input().split())
    res = 0
    A = []
    for i in range(m):
        u, v, w = map(int, input().split())
        A.append((u, v, w))
    A.sort(key=lambda x: x[2])  # sx trọng số tăng dần
    print(A)
    for u, v, w in A:
        x = root(u)
        print("x: %d" % x)

        y = root(v)
        print("y: %d" % y)

        if (x != y):
            while u != x:
                z = F[u]
                F[u] = x
                print("F[%d]: %d" % (u, F[u]))

                u = z
                print("u: %d" % u)
            while v != y:
                z = F[v]
                F[v] = x
                print("F[%d]: %d" % (v, F[v]))
                v = z
                print("v: %d" % v)
            F[y] = x
            print("F[%d]: %d" % (y, F[y]))

            res += w
            print("res: %d" % res)
    print(res)
    print(F)
if __name__ == '__main__':
    sol()


'''
5 4
1 2 4
2 4 3
4 3 1
4 5 4
'''