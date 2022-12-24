
'''
#bán tre
tien = 0
def TRY(a,k):
    global tien
    for i in a:
        m = i // k
        tien += m * 3 * k



n,k = map(int,input().split())
a = list(map(int,input().split()))
TRY(a,k)
print(tien)


#sinh tajap con
def TRY(x, n, k):
    if len(x) == k:
        print(*x, sep=' ')
    else:
        for t in range(1, n+1):
            if t not in x and ((t > x[-1]) if len(x) > 0 else 1):
                TRY(x + [t], n, k)

if __name__ == '__main__':
    n, k = map(int, input().split())
    TRY([], n, k)

'''





def Check(A, B, C):
    if (A + B <= C or B + C <= A or A + C <= B):
        return False
    if (abs(A - B) >= C or abs(B - C) >= A or abs(C - A) >= B):
        return False
    return True
res = "no"

def Try(i, M, T1, T2, dem1, dem2):
    global res
    if (res == "yes"): return
    if (i == 6):
        if (Check(T1[0], T1[1], T1[2]) == True and Check(T2[0], T2[1], T2[2]) == True):
            res = "yes"
    else:
        if (dem1 < 3):
            T1.append(M[i])
            Try(i + 1, M, T1, T2, dem1 + 1, dem2)
            T1.pop()
        if (dem2 < 3):
            T2.append(M[i])
            Try(i + 1, M, T1, T2, dem1, dem2 + 1)
            T2.pop()

if __name__ == '__main__':
    t = int(input())
    a = []
    for i in range(1,t+1):
        a.append(list(map(int,input().split())))
    for i in range(len(a)):
        Try(0,a,[],[],0,0)
    print(res)




