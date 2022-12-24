

#chia của

'''

T=0
res = 1e9
def TRY(x,a):
    global T,res
    if(len(x)==len(a)):
        Anh = sum([u*v for u,v in zip(x,a)])
        Em = T-Anh
        if res > abs (Anh-Em):
            res = abs(Anh-Em)
    else:
        for t in range(2):
            TRY(x+[t],a)
if __name__ == '__main__':
    n = int(input())
    a = list(map(int,input().split()))
    T = sum(a)
    TRY([],a)
    print(res)


'''

#chia gạo
G = []
res = 1e9
def TRY(a,A,b,B,c,C,k):
    global res
    if k==9:
        res = min(res,max(A,B,C)-min(A,B,C))
    else:
        if a<3: TRY(a+1,A+G[k],b,B,c,C,k+1)
        if b<3: TRY(a,A,b+1,B+G[k],c,C,k+1)
        if c<3: TRY(a,A,b,B,c+1,C+G[k],k+1)

if __name__ == '__main__':
    G = list(map(int,input().split()))
    TRY(0,0,0,0,0,0,0)
    print(res)







#suc mạnh tập thể
from itertools import product

n,k=map(int,input().split())
a=[]
for i in range(n):
    u,*v=map(int,input().split())
    a.append(v)
res=-1
for x in product(*a):
    t=[z*z%k for z in x]
    t=sum(t)%k
    if t>res: res=t
print(res)






