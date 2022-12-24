

#dãy nhị phân
'''

def Try(x,n):
    if len(x)==n:
        print(x)
    else:
        for t in ['0','1']:
            Try(x+t,n)

if __name__ == '__main__':
    Try('',int(input()))

'''



#dãy tam phân
'''
dem = 0
def Try(x,n):
    global dem
    if len(x)==n:
        print(*x , sep=' ')
        dem+=1
    else:
        for t in ['0','1','2']:
            if x == '' or (x[-1]!=t and (int(x[-1]) + int(t))%3!=0):
                Try(x+t,n)

if __name__ == '__main__':
    Try('',int(input()))
    print(dem)
'''




#liệt kê hoán vị
'''
def TRY(x,n):
    if len(x)==n:
        print(*x, sep='')
    else:
    else:
        for t in range(1,n+1):
            if t not in x: TRY(x+[t],n)

if __name__ == '__main__':
    TRY([], int(input()))

'''




'''
from itertools import permutations
n = int(input())
A = permutations(range(1,n+1))
for x in A: print(*x,sep='')
'''


'''
    Hoán vị 4
d=[0]*100
dem = 0
def TRY(x,n):
    global dem
    if len(x)==n:
        print(*x,sep=' ')
        dem = dem+1
    else:
        for t in range(1,n+1):
            if len(x)==0 or (d[t]==0 and (x[-1]+t)%4!=0):
                d[t] = 1
                TRY(x+[t],n)
                d[t] = 0

if __name__ == '__main__':
    TRY([], int(input()))
    print (dem)

'''

'''
    hoán vị lặp
    def TRY(x,n,L,D):
    if len(x)==n: print(x)
    else:
        for k in L:
            if D[k]>0:
                D[k]-=1
                TRY(x+k,n,L,D)
                D[k]+=1
    from collections import  Counter
    if __name__ == '__main__':
        x = input()
        D = Counter(x)
        L = sorted(D.keys())
        TRY('',len(x),D)

'''
from collections import Counter

def TRY(x, n, L, D):
    if len(x) == n:
        print(x)
    else:
        for k in L:
            if D[k] > 0:
                D[k] -= 1
                TRY(x + k, n, L, D)
                D[k] += 1

if __name__ == '__main__':
    x = input()
    D = Counter(x)
    L = sorted(D.keys())
    TRY('', len(x), L,D)





























