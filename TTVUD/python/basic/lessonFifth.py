



# cấu trúc dữ liệu


# Hàng đợi: queue
# from queue import *
# Q = Queue()
# for x in [6,7,4,33,5]: Q.put(x)
# while Q.qsize():
#     print(Q.get(),end=" ")



# ngan xep: stack
# from queue import *
# Q = LifoQueue()
# for x in [4,6,7,4,3,3,7]: Q.put(x)
# while Q.qsize():
#     print(Q.get(),end=" ")



# hafng dọi ưu tiên bé đến  lơns
# from queue import *
# Q = PriorityQueue()
# for x in [4,6,7,4,3,3,7]: Q.put(x)
# while Q.qsize():
#     print(Q.get(),end=" ")


# hafng dọi ưu tiên ngược lại
# from queue import *
# Q = PriorityQueue()
# for x in [4,6,7,4,3,3,7]: Q.put(-x)
# while Q.qsize():
#     print(-Q.get(),end=" ")




# sap xep theo uu tiên nào đó
# import queue
# class item:
#     def __init__(self,x):
#         self.val = x
#
#     def __lt__(self, other): #lesser than
#         return self.val < other.val  if self.val%3 == other.val%3 else self.val%3 < other.val%3
#
#
# if __name__ == '__main__':
#     Q = queue.PriorityQueue()
#     for x in [45,567,235,547,678,745,234,6,8]:
#         Q.put(item(x))
#     while Q.qsize():
#         print(Q.get().val, end=" ")



# ptu trung vị: thêm vào là sx
# import queue
# L = queue.PriorityQueue()
# R = queue.PriorityQueue()
# n, *a = list(map(int,input("").split()))
# for i,x in enumerate(a):
#     if i%2:
#         R.put(x) #sx tăng dần
#     else:
#         L.put(-x) #sx tăng dần
#
#     if i > 0 and -L.queue[0] > R.queue[0]:
#         u,v = L.get(),R.get()
#         L.put(-v)
#         R.put(-u)
#     print(-L.queue[0],end=" ")




# mọi con đường về không
import math
from queue import *
# def bfs(n):
#     Q = Queue()
#     d = [0] * (n + 5) #mang danh dau toan 0
#     Q.put(n)
#     d[n] = 1 #dánh dấu đã đi qua.
#     while(Q.qsize()):
#         u = Q.get()
#         for i in range(1, int(math.sqrt(u) + 1)):
#             if u % i ==0:
#                 v = (i-1) * (u//i + 1)
#                 if d[v]==0:
#                     Q.put(v)
#                     d[v] = 1
#
#     for i in range (n+1):
#         if d[i]==1:
#             print(i)
#
# if __name__ == '__main__':
#     n = int(input())
#     bfs(n)



#cho n va m trong bai moi con duong ve khong: d[] lưu thằng cha nó
import math
from queue import *
def inkq(d,n,m):
    if n==m: return [m]
    else:
        return inkq(d,n,d[m]) + [m]
def bfs(n,m):
    Q = Queue()
    d = [0] * (n + 5) #mang danh dau toan 0
    Q.put(n)
    while(Q.qsize()):
        u = Q.get()
        for i in range(1, int(math.sqrt(u) + 1)):
            if u % i ==0:
                v = (i-1) * (u//i + 1)
                if d[v]==0 and v >=m:
                    Q.put(v)
                    d[v] = u
                if v==m:
                    print(*inkq(d,n,m), sep="->")
                    return ;


    print("Khong co duong di")

if __name__ == '__main__':
    n = int(input("nhap n: "))
    m = int(input("nhap m: "))
    bfs(n,m)