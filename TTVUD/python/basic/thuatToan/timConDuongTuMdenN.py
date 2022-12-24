



# cho n va m trong bai moi con duong ve khong: d[] lưu thằng cha nó
# import math
# from queue import *
# def inkq(d,n,m):
#     if n==m: return [m]
#     else:
#         return inkq(d,n,d[m]) + [m]
# def bfs(n,m):
#     Q = Queue()
#     d = [0] * (n + 5) #mang danh dau toan 0
#     Q.put(n)
#     while(Q.qsize()):
#         u = Q.get()
#         for i in range(1, int(math.sqrt(u) + 1)):
#             if u % i ==0:
#                 v = (i-1) * (u//i + 1)
#                 if d[v]==0 and v >=m:
#                     Q.put(v)
#                     d[v] = u
#                 if v==m:
#                     print(*inkq(d,n,m), sep="->")
#                     return ;
#
#
#     print("Khong co duong di")
#
# if __name__ == '__main__':
#     n = int(input("nhap n: "))
#     m = int(input("nhap m: "))
#     bfs(n,m)