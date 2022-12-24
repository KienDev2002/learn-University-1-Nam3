''' CNTT2K61
a=input("xin moi cho biet quy danh: ")
print('xin chao',a)

n=int(input('nhap n = '))
print(n**3)


a,b=input().split()
a=float(a)
b=float(b)
a,b=3,4
print("Dien tich HCN",a*b)

a=list(input().split())
print(a)
print(*a,sep=" và ")

a=input().split()
a=list(map(int,a))
print(a)
print("sum : ",sum(a))

x,y,*a,z=input().split()
print(x,y,z)
print(a)




a,b=map(int,input().split())
if a>b:
    x=a
    y=b
else:
    x=b
    y=a
print("max : ",x,end=" ")
print("min : ",y,end=" ")


a,b,c,d=map(int,input().split())
if a<b: a,b=b,a
if c<d: c,d=d,c
if a==c==b+d : print("YES")
else:print("NO")

a,b,c=map(int,input().split())
if (a-b)*(a-c)<0: print(a)
elif (b-c)*(b-a)<0: print(b)
elif (c-a)*(c-b)<0: print(c)
else: print("khong co")

from math import sqrt
a,b,c=map(float,input().split())
d=b*b-4*a*c
if a==b==c==0: print("vo so nghiem")
elif a==b==0 or d<0:print("vo nghiem")
elif a==0: print(-c/b)
elif d==0: print(-b/2/a)
else:
    x1=(-b-sqrt(d))/2/a
    x2=-b/a-x1
    print(x1,x2,sep="\n")


n=int(input())
#print("chan") if n%2==0 else print("le")
print("chan" if n%2==0 else "le")

#a=range(-10,10,2)
a=list(range(10))
a.append(14)
print(*a)
print(a[0],a[1],a[-2],a[-1])
b=a[::-1]
print("b : ",*b)

#dao xau
a=input()[::-1]
print(a)

a=input().split()
print(*a[::-1])

def f(x): return 1-x%2
a=[4,7,0,2,-8]
print("So so chan ",sum(map(f,a)))
print("So so duong ",sum(map(lambda x: 1 if x>0 else 0,a)))
b=filter(lambda x:x>0,a)
print("Cac so duong gom : ",*b)
a.sort(reverse=True)
print(*a)


#B02  ngay 22_8_22
#lenh for
for x in range (10): print(x,end =" ")

#tinh n!
n=int(input())
s=1
for x in range(1,n+1) : s*=x
print("n! = ",s)

#nhap n tinh s=1*n+2*(n-1)+...+n*1
n=int(input())
s=0
for i in range(1,n+1) : s+=i*(n+1-i)
print("s = ",s)


#ham zip
a=[1,2,3,4,5]
b=['a','b','c']
c=list(zip(a,b,a[::-1]))
print(c)

#s=1*a+2*3+...+(n-1)*n
n=int(input())
a=list(range(1,n+1))
s=0
for x,y in zip(a,a[1:]): s+=x*y
print(s)


#kiem tra so nguyen to
from math import sqrt
n=int(input())
m=int(sqrt(n))
ok=True
for i in range(2,m+1):
    if n%i==0:
        ok=False
        break
print("yes" if ok and n>1 else "no")

#in ra day fibonacci
n=int(input())
F=2*[1]
for _ in range(n): F.append(F[-1]+F[-2])
print(*F[:n])


#nhap day so nguyen va tinh
#s1 tong binh phuong cac phan tu
#s2 tong nhung so chan


a=list(map(int,input().split()))
b=[x*x for x in a]
print(sum(b))
c=[x for x in a if x%2==0]
if c==[]: print("khong co so chan")
else:print("tong chan ",sum(c))
#s3=a1+(a1+a2)+(a1+a2+a3)+...(a1+...+an)
=n*a1+(n-1)*a2+...+1*an
s=0
for i,x in enumerate(a): s+=sum(a[:i+1])
print(s)
a=[4,7,2,8,1]
for i,x in enumerate(a): print(i,x)

#nhap day so nguyen kiem tra day co tang dan khong? a1<a2<...<an?
a=list(map(int,input().split()))
b=[0 for x,y in zip(a,a[1:]) if x>=y]
print("day tang" if b==[] else "khong phai day tang")

a=list(map(int,input().split()))
print("doi xung" if a==a[::-1] else "khong doi xung")


#dem so bo 3 lien tiep tao cap so cong
a=list(map(int,input().split()))
b=[1 for x,y,z in zip(a,a[1:],a[2:]) if x+z==2*y]
print("So bo 3 lien tiep csc : ",sum(b))

#lenh while
#nhap n tinh tong cac chu so
n=int(input())
s=0
while n>0:
    s+=n%10
    n=n//10  # chu y / chia so thuc // chia nguyen
print(s)
# cach 2 : print(sum(map(int,input())))

#giai phuong trinh x^x=a voi a thuoc [1,10^10]
a=float(input())
L,R=1,10
while R-L>1e-5:
    M=(L+R)/2
    if pow(M,M)>a: R=M
    else: L=M
print("x = ",L)

from math import sqrt
def kc(x,y,z,t): return ((x-z)*(x-z)+(y-t)*(y-t))
if __name__ == '__main__':
    xO,yO,r,xM,yM=map(float,input().split())
    if kc(xO,yO,xM,yM)>r*r:
        xP,yP=xO,yO
        while abs(xP-xM)>1e-5 or abs(yP-yM)>1e-5:
            xQ=(xP+xM)/2
            yQ=(yP+yM)/2
            if kc(xO,yO,xQ,yQ)>r*r: xM,yM=xQ,yQ
            else: xP,yP=xQ,yQ
    print(xM, yM)


#29_8_2022
#cau truc
from collections import namedtuple
diem=namedtuple('Point',"x y")
if __name__ == '__main__':
    A=diem(3,4)
    B=diem(5,6)
    print(A)
    print(B.x,B.y)
#dien tich tam giac ABC
import math
from collections import namedtuple
diem=namedtuple('Point',"x y")
def kc(A,B): return math.sqrt((A.x-B.x)**2+(A.y-B.y)**2)
def dt(A,B): return A.x*B.y-A.y*B.x
if __name__ == '__main__':
    x,y=map(float,input("A : ").split())
    A=diem(x,y)
    x,y=map(float,input("B : ").split())
    B=diem(x,y)
    x,y=map(float,input("C : ").split())
    C=diem(x,y)
    print("S1= %0.3f"%(abs(dt(A,B)+dt(B,C)+dt(C,A))/2))
    a,b,c=kc(B,C),kc(C,A),kc(A,B)
    p=(a+b+c)/2
    print("S2= %0.3f"%(math.sqrt(p*(p-a)*(p-b)*(p-c))))

#dien tich tu giac
from collections import namedtuple
diem=namedtuple("Diem","x,y")
def dt(A,B): return A.x*B.y-A.y*B.x
if __name__ == '__main__':
    D=[]
    for i in range(4):
        x,y=map(float,input("A"+str(i+1)+" : ").split())
        D.append(diem(x,y))
    D.append(D[0])
    s=0
    for A,B in zip(D,D[1:]): s+=dt(A,B)
    print("Dien tich tu giac %.6f"%(abs(s)/2))


#tim diem trong tam giac gan voi diem M cho truoc nhat
from collections import namedtuple
diem=namedtuple('D',"x,y")
def dt(A,B): return A.x*B.y-A.y*B.x
def S(A,B,C): return abs(dt(A,B)+dt(B,C)+dt(C,A))/2
def bpkc(A,B): return (A.x-B.x)**2+(A.y-B.y)**2
def tim(A,B,M): # tim diem tren A,B gan M nhat
    while abs(A.x-B.x)>1e-6 or abs(A.y-B.y)>1e-6:
        C=diem((A.x+B.x)/2,(A.y+B.y)/2)
        if bpkc(A,M)>bpkc(B,M): A=C
        else:B=C
    return A,bpkc(A,M)
if __name__ == '__main__':
    x, y = map(float, input().split())
    A = diem(x, y)
    x, y = map(float, input().split())
    B = diem(x, y)
    x, y = map(float, input().split())
    C = diem(x, y)
    x, y = map(float, input().split())
    M = diem(x, y)
    if S(A,B,C)==S(A,B,M)+S(A,C,M)+S(B,C,M): print("%.3f %.3f"%(M.x,M.y))
    else:
        A1,u=tim(B,C,M)
        B1,v=tim(C,A,M)
        C1,t=tim(A,B,M)
        z=min(u,v,t)
        E=A1 if z==u else (B1 if z==v else C1)
        print("%.3f %.3f" % (E.x, E.y))

# cau truc sinh vien gom ho ten, tuoi, diem
# nhap va xuat
# sap xep danh sach theo diem giam dan
# sap xep ds theo ten tang dan
# in ra sv co diem cao nhat
from collections import namedtuple
sv=namedtuple('SV',"ten tuoi diem")
def nhap(fname):
    f=open(fname,"r")
    S=[]
    for i in range(int(f.readline())):
        a,b,c=f.readline().rsplit(None,2)
        S.append(sv(a,int(b),float(c)))
    f.close()
    return S
def xuat(S):
    for s in S: print("%-20s %5d %6.2f"%(s.ten,s.tuoi,s.diem))
if __name__ == '__main__':
    S=nhap("sv.txt")
    print("Danh sach sinh vien vua nhap")
    xuat(S)
    print("Danh sach diem giam dan")
    S.sort(key=lambda x:x.diem,reverse=True)
    xuat(S)
    print("Danh sach sap theo ten")
    S.sort(key=lambda x:x.ten.split()[-1])
    xuat(S)
    print("Sinh vien co diem cao nhat",max(S,key=lambda x:x.diem))
    print("Tuoi trung binh %f"%(sum([x.tuoi for x in S])/len(S)))
    print("Danh sach sv co diem >6")
    T=[x for x in S if x.diem>6]
    xuat(T)


#ngay 05/09/2022
#tinh so ngay tu d1/m1/y1->d2/m2/y2

def nhuan(y): return y%400==0 or (y%4==0 and y%100!=0)
def songay(d,m,y): #so ngay 1/1/1->d/m/y
    for i in range(1,y): d+=365+nhuan(i)
    t=[0,31,28+nhuan(y),31,30,31,30,31,31,30,31,30,31]
    return d+sum(t[:m])
if __name__ == '__main__':
    d1,m1,y1=map(int,input("ngay bd : ").split('/'))
    d2,m2,y2=map(int,input("ngay kt : ").split('/'))
    print(songay(d2,m2,y2)-songay(d1,m1,y1))


#dem so nghiem phuong trinh trung phuong ax^4+bx^2+c=0 (at^2+bt+c=0)
from math import sqrt
def dem(t): return [] if t<0 else ([0] if t==0 else [-sqrt(t),sqrt(t)])
def pt(a,b,c):
    if a==0: res=[] if b==0 else dem(-c/b)
    else:
        b/=2
        d=b*b-a*c
        if d>0: res=dem((-b-sqrt(d))/a)+dem((-b+sqrt(d))/a)
        else: res=[] if d<0 else dem(-b/a)
    res.sort()
    return res
if __name__ == '__main__':
    a,b,c=map(float,input().split())
    if a==b==c==0: print("vo so nghiem")
    else: print(pt(a,b,c))

#tim so fibonacci thu n
#c1
def fibo(n): #O(n)
    f=[1,1]
    for i in range(n): f.append(f[-1]+f[-2])
    return f[n]
#c2
def fib(n):  #O(2^n)
    if n<2: return 1
    return fib(n-1)+fib(n-2)
#c3
d={}
def Fib(n): #O(n) - dung tu dien
    global d
    if n in d.keys(): return d[n]
    d[n] = 1 if n<2 else Fib(n-1)+Fib(n-2)
    return d[n]
#c4
def Fi(n):
    if n<2: return 1,1
    a,b=Fi(n-1)
    return b,a+b

#c5
def F(n):
    if n<2: return 1,1
    x,y=F(n//2)
    if n%2==0: return x*x+y*y,2*x*y-y*y
    else: return x*x+2*x*y,x*x+y*y
if __name__ == '__main__':
    for i in range(1000,1001):
        a,b=F(i)
        print(i,a)

class ps:
    def __str__(self): return str(self.t)+"/"+str(self.m)
    def __init__(self,s=0,t=1): self.t, self.m=s,t
    def __add__(self, other):
        return ps(self.t*other.m+self.m*other.t,self.m*other.m)
if __name__ == '__main__':
    p=ps(2,-3)
    q=ps(5,1)
    print(p+q+p)

#Ngay 12/9/2022

































-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
















#cau truc du lieu

from queue import *
#Q=Queue()
#Q=LifoQueue()
Q=PriorityQueue()
for x in [4,7,2,8,1,6]: Q.put(-x)
while Q.qsize(): print(-Q.get(),end=" ")


import queue
class item:
    def __init__(self,x): self.val=x
    def __lt__(self, other):
        return self.val< other.val if self.val%3==other.val%3 else self.val%3 < other.val%3
if __name__ == '__main__':
    Q=queue.PriorityQueue()
    for x in [312,142,15,1,15,2,623,23,234]: Q.put(item(x))
    while Q.qsize():
        print(Q.get().val,end= " ")

#phan tu trung vi
import queue
import sys
if __name__ == '__main__':
    L=queue.PriorityQueue()
    R=queue.PriorityQueue()
    #n,*a=list(map(int,sys.stdin.read().split()))
    n,*a=list(map(int,input().split()))
    for i,x in enumerate(a):
        if i%2: R.put(x)
        else:L.put(-x)
        if i>0 and -L.queue[0]>R.queue[0]:
            u,v=L.get(),R.get()
            L.put(-v)
            R.put(-u)
        print(-L.queue[0],end =" ")


# tim duong di trong bai moi con duong ve 0
import math
import queue
def inkq(d,n,m):
    if n==m: return [m]
    return inkq(d,n,d[m])+[m]
def BFS(n,m):
    Q=queue.Queue()
    d=[0]*(n+5)
    Q.put(n)
    while Q.qsize():
        u=Q.get()
        for a in range(1,math.floor(math.sqrt(u))+1):
            if u%a==0:
                v=(a-1)*(u//a+1)
                if v>=m and d[v]==0:
                    Q.put(v)
                    d[v]=u
                if v==m:
                    print(*inkq(d,n,m),sep="->")
                    return
    print("khong co duong di")
if __name__ == '__main__':
    BFS(30,10)

#ngay 19/9/2022
#dong nuoc
#tuble vs list

a=[12,4,24,52,52]  #read and write
b=(12,3,52,62)     #read only
a[1]=5
b[1]=7
print(a[1:3])
print(b[1:3])


import queue
class Water:
    P = {}   #mang cha (trang thai nao do trang thai nao sinh ra
    def nhap(self):
        self.n,self.m,self.k=map(int,input().split())
    def inkq(self,v):
        if v[0]==v[1]==0: print("(0,0)",end="")
        else:
            self.inkq(self.P[v])
            print("->(%d,%d)"%(v[0],v[1]),end="")
    def BFS(self):
        Q=queue.Queue()
        Q.put((0,0))
        self.P[(0,0)]=(-1,-1)
        while Q.qsize():
            x,y=Q.get()
            z=x+y
            Next=[(0,y),(x,0),(self.n,y),(x,self.m),(max(0,z-self.m),min(z,self.m)),(min(z,self.n),max(0,z-self.n))]
            for v in Next:
                if v not in self.P.keys():
                    Q.put(v)
                    self.P[v]=(x,y)
                    if v[0]==self.k or v[1]==self.k:
                        self.inkq(v)
                        return
        print("khong dong duoc nuoc")

if __name__ == '__main__':
    W=Water()
    W.nhap()
    W.BFS()



import queue
class Image:
    res=[]
    def nhap(self):
        self.n,self.m=map(int,input().split())
        self.A=[[1]*(self.m+2)]
        for i in range(self.n):
            z=list(map(int,input().split()))
            self.A.append([1]+z+[1])
        self.A.append([1] * (self.m + 2))
    def xuat(self):
        for a in self.A: print(*a)
    def sol(self):
        for i in range(1,self.n+1):
            for j in range(1,self.m+1):
                if self.A[i][j]==0:
                    self.BFS(i,j)
        self.res.sort()
        print(len(self.res))
        print(*self.res)
    def BFS(self,u,v):
        d=1
        self.A[u][v]=1
        Q=queue.Queue() #Q=queue.LifoQueue()
        Q.put((u,v))
        while Q.qsize():
            x,y=Q.get()
            for i in [-1,0,1]:  #duyet 2 vong lap 9 o gom no va 8 lang gieng
                for j in [-1,0,1]:
                    if self.A[x+i][y+j]==0:
                        Q.put((x+i,y+j))
                        self.A[x+i][y+j]=1
                        d+=1
        self.res.append(d)
if __name__ == '__main__':
    I=Image()
    I.nhap()
    #I.xuat()
    I.sol()


#ngay 26/9/2022
#noi thanh kim loai
import queue
Q=queue.PriorityQueue()
n=input()
for x in input().split(): Q.put(int(x))
res=0
while Q.qsize()>1:
    u=Q.get()+Q.get()
    res+=u
    Q.put(u)
print(res)

#giao hang
from queue import PriorityQueue
A=[[] for i in range(100005)]
n=int(input())
for i in range(n):
    t,v=map(int,input().split())
    A[t].append(v)
res=0
Q=PriorityQueue()
for i in range(100000,0,-1):
    for x in A[i]: Q.put(-x)
    if Q.qsize(): res+=Q.get()
print(-res)

class PQ:
    def __init__(self,ok=False):
        self.a=[]
        self.ut=ok
    def empty(self): return len(self.a)==0
    def qsize(self): return len(self.a)
    def top(self): return self.a[0]
    def put(self,x):
        self.a.append(x)
        k=len(self.a)-1
        while k>0 and (self.a[(k-1)//2]<self.a[k])==self.ut:
            self.a[(k-1)//2],self.a[k]=self.a[k],self.a[(k-1)//2]
            k=(k-1)//2
    def Heapy(self,k):
        p=2*k+1
        if p>=len(self.a): return
        if p+1<len(self.a) and (self.a[p]<self.a[p+1])==self.ut: p+=1
        if (self.a[k]<self.a[p])==self.ut:
            self.a[k],self.a[p]=self.a[p],self.a[k]
            self.Heapy(p)
    def get(self):
        x=self.a[0]
        self.a[0]=self.a[-1]
        self.a.pop()
        if len(self.a)>0: self.Heapy(0)
        return x
if __name__ == '__main__':
    Q=PQ(True)
    for x in ["chipheo","thino","laohac","onggiao","bakien","lycuong","baba","cauvang"]: Q.put(x)
    while Q.qsize(): print(Q.get(),end=" ")


#Ngay 3/10/2022
#trinh tham
import queue
n,k=map(int,input().split())
Q=queue.PriorityQueue()
for i,x in enumerate(map(int,input().split()),1):
    Q.put((-x,i))
    if i>=k:
        while i-Q.queue[0][1]>=k:Q.get()
        print(-Q.queue[0][0],end=" ")


#thuat toan Dijkstra
import queue


class Graph:
    def nhap(self,fname):
        f=open(fname)
        self.n,self.m=map(int,f.readline().split())
        self.A=[[] for i in range(self.n+1)]
        for i in range(self.m):
            u,v,w=map(int,f.readline().split())
            self.A[u].append((w,v))
        f.close()
        #print(self.A)
    def inkq(self,s,v):
        if s==v: print(s,end="")
        else:
            self.inkq(s,self.P[v])
            print("->%d"%v,end="")
    def Dijkstra(self,s): #tim duong di ngan nhat tu s den cac dinh
        Q=queue.PriorityQueue()
        Q.put((0,s))
        L=[1e9]*(self.n+2)
        self.P=[-1]*(self.n+2)
        L[s]=0
        while Q.qsize():
            d,u=Q.get()
            if L[u]<d: continue
            for z,v in self.A[u]:
                if L[v]>d+z:
                    L[v]=d+z
                    self.P[v]=u
                    Q.put((d+z,v))
        for i in range(1,self.n+1):
            print("\nddnn tu %d den %d la %d"%(s,i,L[i]))
            self.inkq(s,i)
if __name__ == '__main__':
    G=Graph()
    G.nhap('g.txt')
    G.Dijkstra(3)


#thuat toan Prim
import queue
class Graph:
    def nhap(self):
        self.n,self.m=map(int,input().split())
        self.A=[[] for i in range(self.n+1)]
        for i in range(self.m):
            u,v,w=map(int,input().split())
            self.A[u].append((w,v))
            self.A[v].append((w,u))
    def Prim(self): #tim cay khung nho nhat
        Q=queue.PriorityQueue()
        Q.put((0,1))
        L=[0,0]+[1e9]*(self.n+2)
        s=0
        P=[0]*(self.n+2)
        while Q.qsize():
            d,u=Q.get()
            if L[u]<d: continue
            s+=L[u]
            L[u]=-1   #Danh dau da xet sang -1
            for z,v in self.A[u]:
                if L[v]>z:
                    L[v]=z
                    P[v]=u
                    Q.put((z,v))
        print(s)
        for i in range(2,self.n+1):
            print("chon canh %d %d"%(P[i],i))
if __name__ == '__main__':
    G=Graph()
    G.nhap()
    G.Prim()


#ngay 10/10/2022
#truy van max dung cay IT
class node:
    def __init__(self,a,b):
        self.L,self.R=a,b
        self.elem=-1e9
        if a==b: self.left,self.right=None,None
        else:
            self.left=node(a,(a+b)//2)
            self.right=node((a+b)//2+1,b)
def update(H,i,x):
    if H.elem<x: H.elem=x
    if H.left!=None: update(H.left if i<=H.left.R else H.right,i,x)
def get(H,u,v):
    if u==H.L and v==H.R : return H.elem
    if u<=H.left.R and H.right.L<=v: return max(get(H.left,u,H.left.R),get(H.right,H.right.L,v))
    return get(H.left if v<=H.left.R else H.right,u,v)
if __name__ == '__main__':
    n,m=map(int,input().split())
    H=node(1,n)
    for i,x in enumerate(input().split(),1): update(H,i,int(x))
    for i in range(m):
        u,v=map(int,input().split())
        print(get(H,u,v))

#ngay 17/10/2022
#Dem so nghich the

A=[0]*400005
res=0
def update(k,L,R,x):
    global A
    global res
    A[k]+=1
    if L==R: return
    if x<=(L+R)//2:
        res+=A[2*k+2]
        update(2*k+1,L,(L+R)//2,x)
    else: update(2*k+2,(L+R)//2+1,R,x)
if __name__ == '__main__':
    n=int(input())
    for x in map(int,input().split()): update(0,1,n,x)
    print(res)



class node:
    def __init__(self,a,b):
        self.elem=0
        self.end=b
        if a==b: self.L,self.R=None,None
        else: self.L,self.R=node(a,(a+b)//2),node((a+b)//2+1,b)
res=0
def update(H,x):
    global res
    H.elem+=1
    if H.L!=None:
        if x<=H.L.end:
            res+=H.R.elem
            update(H.L,x)
        else: update(H.R,x)

if __name__ == '__main__':
    n=int(input())
    H=node(1,n)
    for x in map(int,input().split()): update(H,x)
    print(res)

#thuc hanh sang thu 4 online tu 7h->12h



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
    for i in range(m):
        u,v=map(int,input().split())
        x,y=root(u),root(v)
        if x!=y:
            g-=1
            while u!=x:
                z=F[u]
                F[u]=x
                u=z
            while v!=y:
                z=F[v]
                F[v]=x
                v=z
            F[y]=x
            D[x]+=D[y]
            if res<D[x] :res=D[x]
    print(g,res,sep="\n")
if __name__ == '__main__':
    sol()


#thuc hanh 19/10/2022
from collections import namedtuple
if __name__ == '__main__':
    sv=namedtuple("sv","ten diem")
    D=[]
    K=[]
    n=int(input())
    for i in range(n):
        t,d,k=input().rsplit(None,2)
        if k=="DDT": D.append(sv(t,int(d)))
        else: K.append(sv(t,int(d)))
    D.sort(key=lambda x:x.diem,reverse=True)
    k=max(K,key=lambda x:x.diem)
    print("Giai nhat :%s"%(D[0].ten))
    print("Giai nhi :%s"%(D[1].ten))
    print("Giai ba :%s"%(D[2].ten))
    print("Giai giao luu :%s"%(k.ten))

#sap xep ds sinh vien
import sys
import datetime
import collections
#for ip in sys.stdin: print(ip)
#d=datetime.datetime(2022,10,19)
#print(d)
if __name__ == '__main__':
    sv=collections.namedtuple("sv","ten,ngay,gioi,id")
    D=[]
    for i,ip in enumerate(sys.stdin):
        t,n,g=ip.rsplit(None,2)
        d,m,y=n.split('/')
        D.append(sv(t,datetime.datetime(int(y),int(m),int(d)),g,i))
    D.sort(key=lambda x: (x.ngay,x.id))
    for x in D: print("%s %d/%d/%d %s"%(x.ten,x.ngay.day,x.ngay.month,x.ngay.year,x.gioi))

#tinh diem thi lap trinh

from collections import namedtuple
sv=namedtuple("sv","A,B,C,D")
d=[4,7,2,8]
x=sv._make(d)
x=x._replace(A=6)
print(x.A)

import collections
if __name__ == '__main__':
    n=int(input())
    sv=collections.namedtuple("SV",input()+" TD")
    DS=[]
    for i in range(n):
        x=input()+" 0"
        y=sv._make(x.split())
        y=y._replace(TD=int(y.A)+2*int(y.B)+3*int(y.C)+4*int(y.D)+5*int(y.E))
        DS.append(y)
    DS.sort(key=lambda x:x.TEN)
    for s in DS: print(s.TEN,s.TD)

from queue import LifoQueue
ut={'(':0,'+':1,'-':1,'*':2,'/':2}
def balan(ip):
    global ut
    out=""
    S=LifoQueue()
    for c in ip:
        if '0'<=c<='9': out+=c
        elif c=='(': S.put(c)
        elif c==')':
            while S.queue[-1]!='(': out+=S.get()
            S.get()
        else: #toan tu +,-,*,/
            while S.qsize() and ut[S.queue[-1]]>=ut[c]: out+=S.get()
            S.put(c)
    while S.qsize(): out+=S.get()
    return out
def tinh(out):
    S=LifoQueue()
    for c in out:
        if '0'<=c<='9': S.put(int(c))
        else:
            a,b=S.get(),S.get()
            if c=='+':S.put(b+a)
            elif c=='-':S.put(b-a)
            elif c=='*':S.put(b*a)
            else : S.put(b//a)
    return S.get()
if __name__ == '__main__':
    out=balan(input())
    print(out)
    print(tinh(out))

#chao don sv K59
import queue

if __name__ == '__main__':
    n=int(input())
    a=list(map(int,input().split()))
    S=queue.LifoQueue()
    S.put((-1,1e9))
    L=[0]*(n+5)
    for i,x in enumerate(a):
        while S.queue[-1][1]<=x: S.get()
        L[i]=S.queue[-1][0]
        S.put((i,x))
    #print(L)
    R=[0]*(n+5)
    S=queue.LifoQueue()
    S.put((-1,1e9))
    for i in range(n-1,-1,-1):
        while S.queue[-1][1] <= a[i]: S.get()
        R[i] = S.queue[-1][0]
        S.put((i, a[i]))
    #print(R)
    for i in range(n):
        if L[i]==-1 or R[i]==-1: print(L[i]+R[i]+1,end=" ")
        else: print(L[i] if i-L[i]<=R[i]-i else R[i],end=" ")

#ngay 24/10/2022
#Thuat toan Kruskal

F=[0]*10001
def root(x): #return x if F[x]==0 else root(F[x])
    while F[x]: x=F[x]
    return x
if __name__ == '__main__':
    n,m=map(int,input().split())
    res=0
    A=[]
    for i in range(m):
        u,v,w=map(int,input().split())
        A.append((u,v,w))
    A.sort(key=lambda x: x[2])
    #print(A)
    for u,v,w in A:
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
            F[y]=x
            res+=w
    print(res)


if __name__ == '__main__':
    M={}
    n=input()
    L,res=0,-1
    for i,x in enumerate(map(int,input().split())):
        if x in M.keys() and M[x]>=L: L=M[x]+1
        if res<i-L+1:res=i-L+1
        M[x]=i
        print(res)

#ngay 31_10_2022
#sinh day nhi phan
def TRY(x,n):
    if len(x)==n: print(x)
    else:
        for t in ['0','1']: TRY(x+t,n)
TRY('',int(input()))


#Day tam phan
dem=0
def TRY(x,n):
    global dem
    if len(x)==n:
        print(*x,sep=' ')
        dem+=1
    else:
        for t in range(3):
            if x==[] or (x[-1]!=t and (x[-1]+t)%3!=0):
                TRY(x+[t],n)
if __name__ == '__main__':
    TRY([],int(input()))
    print(dem)


#sinh hoan vi
def TRY(x,n):
    if len(x)==n: print(*x,sep='')
    else:
        for t in range(1,n+1):
            if t not in x: TRY(x+[t],n)
if __name__ == '__main__':
    TRY([],int(input()))


#sinh hoan vi
d=[0]*100
def TRY(x,n):
    if len(x)==n: print(*x,sep='')
    else:
        for t in range(1,n+1):
            if d[t]==0 :
                d[t]=1
                TRY(x+[t],n)
                d[t]=0  #lui
if __name__ == '__main__':
    TRY([],int(input()))

from itertools import permutations
n=int(input())
A=permutations(range(1,n+1))
for x in A: print(*x,sep='')

#Hoan vi lap
RES=[]
def TRY(x,n,D):
    global RES
    if len(x)==n: RES.append(x)
    else:
        for k in D.keys():
            if D[k]>0:
                D[k]-=1
                TRY(x+k,n,D)
                D[k]+=1
from collections import Counter
if __name__ == '__main__':
    x=input()
    D=Counter(x)
    TRY('',len(x),D)
    RES.sort()
    print('\n'.join(RES))


#ngay 2/11/2022
#Lap lich y ta
n,k1,k2=0,0,0
def TRY(x,k):   #gia su da co phan dau x va cuoi xau x co k so 1 lien nhau
    if len(x)==n:
        if k==0 or k>=k1: print(x)
    else:
        if x=='' or k>=k1  : TRY(x+'0',0)
        if k<k2 : TRY(x+'1',k+1)

if __name__ == '__main__':
    n,k1,k2=map(int,input().split())
    TRY('',0)

#lai ghep
a=''
b=''
def TRY(x,i):
    if i==len(a):print(x)
    else:
        u,v=a[i],b[i]
        if u>v: u,v=v,u
        TRY(x+u,i+1)
        if u!=v: TRY(x+v,i+1)

if __name__ == '__main__':
    a=input()
    b=input()
    TRY('',0)


#lai la lai ghep
a=''
b=''
def TRY(x,i):
    if i==len(a): print(x[2:])
    else:
        u,v=a[i],b[i]
        if u>v: u,v=v,u
        if x[-2]=='A' or x[-1]=='A' or u=='A' : TRY(x+u,i+1)
        if u!=v:
            if x[-2]=='A' or x[-1]=='A' or v=='A' : TRY(x+v,i+1)

if __name__ == '__main__':
    a='AA'+input()
    b='AA'+input()
    TRY('AA',2)

#chia cua
res=1e9
a=[]
def TRY(A,E,k,n):
    global T,res
    if k==n:
        if res>abs(A-E): res=abs(A-E)
    else:
        TRY(A+a[k],E,k+1,n)
        TRY(A,E+a[k],k+1,n)

if __name__ == '__main__':
    n=int(input())
    a=list(map(int,input().split()))
    TRY(0,0,0,n)
    print(res)


#Chia gao

G=[]
res=1e9
def TRY(a,A,b,B,c,C,k): #gia su da chi a bao cho A, b bao cho B, c bao cho C voi k=a+b+c
    global res
    if k==9: res=min(res,max(A,B,C)-min(A,B,C))
    else:
        if a<3: TRY(a+1,A+G[k],b,B,c,C,k+1)
        if b<3: TRY(a,A,b+1,B+G[k],c,C,k+1)
        if c<3: TRY(a,A,b,B,c+1,C+G[k],k+1)
if __name__ == '__main__':
    G=list(map(int,input().split()))
    TRY(0,0,0,0,0,0,0)
    print(res)



#suc manh tap the

n,M=0,0
A=[]
res=-1
def TRY(x,k):
    global res
    if k==n:
        s=x%M
        if res<s:res=s
    else:
        for t in A[k]: TRY(x+t*t,k+1)
if __name__ == '__main__':
    n,M=map(int,input().split())
    for i in range(n):
        k,*a=list(map(int,input().split()))
        A.append(a)
    TRY(0,0)
    print(res)


'''

A=[]
n=0
res=1e9
d=[1]+[0]*100
def TRY(x,k,s):  #k so dinh da xet, x la dinh cuoi, s tong duong da di
    global res,n,A,d
    if k==n:
        if s+A[x][0]<res:res=s+A[x][0]
    else:
        for t in range(n):
            if d[t]==0 and s+A[x][t]<res:
                d[t]=1
                TRY(t,k+1,s+A[x][t])
                d[t]=0
if __name__ == '__main__':
    n=int(input())
    for i in range(n):
        a=list(map(int,input().split()))
        A.append(a)
    TRY(0,1,0)
    print(res)




