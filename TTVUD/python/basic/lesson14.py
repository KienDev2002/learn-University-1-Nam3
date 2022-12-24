

# sức mạnh tập thể


n,M = 0,0
A = []
res  = 0
def TRY(x):
    global res
    if len(x)==n:
        s = sum([t*t for t in x]) %M
        if res < s: res = s
    else:
        for t in A[len(x)]: TRY(x+[t])

if __name__ == '__main__':
    n,M = map(int,input().split())
    for i in range(n):
        k , *a = list(map(int,input().split()))
        A.append(a)
    TRY([])
    print(res)




#nguooi di du lich




#người đi du lịch
n = 0
res = 1e9
D = [1] * 100

def TRY(x,A):
    global res, n
    sum = 0
    if len(x)==n:
        z = A[x[n-1]]
        sum += z[x[0]]
        for i in range(n-1):
            t = x[i]
            z = A[t]
            sum+=z[x[i+1]]
        if res > sum:
            res = sum
    else:
        for i in range(n):
            if D[i]==1:
                D[i] = 0
                TRY(x+[i],A)
                D[i] = 1


if __name__ == '__main__':
    n = int(input())
    A = [[] for i in range(n+1)]
    for i in range(n):
        A[i] = list(map(int,input().split()))
    TRY([],A)
    print(res)


