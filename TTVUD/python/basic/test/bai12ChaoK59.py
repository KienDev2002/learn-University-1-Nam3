




import queue




if __name__ == '__main__':
    n = int(input())
    a = list(map(int,input().split()))
    L = [0] * (n)
    S = queue.LifoQueue()
    S.put((-1,1e9))
    for i,x in enumerate(a):
        while S.queue[-1][1] <=x:
            S.get()
        L[i] = S.queue[-1][0]
        S.put((i,x))

    R = [0] * n
    S = queue.LifoQueue()
    S.put((-1,1e9))
    for i in range(n-1,-1,-1):
        while S.queue[-1][1]<=a[i]:
            S.get()
        R[i] = S.queue[-1][0]
        S.put((i,a[i]))

    for i in range(n):
        if L[i]==-1 or R[i] == -1:
            print(L[i] + R[i] + 1, end="\t")
        else:
            print(L[i] if i-L[i] <= R[i] - i else R[i], end="\t")





