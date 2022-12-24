



# cấu trúc.
import math

# dt tam giasc
# from collections import  namedtuple
# diem = namedtuple('Point',"x y") #1 điểm có tên là point và có 2  tp là x và y

# if __name__ == '__main__':
#     A = diem(3,4);
#     B = diem(5,6);
#     print(A);
#     print(B.x,B.y)


# def kc(A,B): return math.sqrt((A.x-B.x)**2 + (A.y-B.y)**2)
# def dt(A,B): return A.x*B.y-A.y*B.x
# if __name__ == '__main__':
#     x,y = map(float,input("A: ").split());
#     A = diem(x,y)
#
#     x, y = map(float, input("B: ").split());
#     B = diem(x, y)
#     x, y = map(float, input("C: ").split());
#     C = diem(x, y)
#
#     print("s1 = %0.3f" %(abs(dt(A,B) + dt(B,C) + dt(C,A))/2))
#
#     a,b,c = kc(B,C), kc(C,A),kc(A,B);
#     p = (a+b+c)/2;
#     print("s2 = %0.3f" %(math.sqrt(p*(p-a) * (p-b) * (p-c))))




# diejen tich tu giac
# from collections import  namedtuple
# diem = namedtuple('Point',"x y")
# def dt(A,B): return A.x*B.y-A.y*B.x
# if __name__ == '__main__':
#     D = []
#     for i in range(4):
#         x,y = map(float,input("A"+str(i+1)+ " : ").split())
#         D.append(diem(x,y))
#     D.append(D[0]) #de tao thanh vong tron
#     s = 0
#     for A, B in zip(D,D[1:]): s+=dt(A,B)
#     print("Dien tich tu giac %.6f"%(abs(s)/2))





# tim diem trong tam giac gan M nhat
# from collections import  namedtuple
# diem = namedtuple('Point',"x y")
# def dt(A,B): return  A.x*B.y-A.y*B.x
# def S(A,B,C): return  abs(dt(A,B)+dt(B,C) + dt(C,A))/2
# def bpkc(A,B): return (A.x-B.x)**2 + (A.y-B.y)**2
# def tim(A,B,M): #tim diem tren doan a b gan M nhat
#      while abs(A.x - B.x) > 1e-6 or abs(A.y - B.y) > 1e-6:
#          C = diem((A.x + B.x)/2 , (A.y+B.y)/2)
#          if(bpkc(A,M) > bpkc(B,M)): A = C
#          else: B = C
#      return B,bpkc(B,M)
#
# if __name__ == '__main__':
#     x, y = map(float, input("a:").split())
#     A = diem(x,y)
#     x, y = map(float, input("b:").split())
#     B = diem(x, y)
#     x, y = map(float, input("c:").split())
#     C = diem(x, y)
#     x, y = map(float, input("m:").split())
#     M = diem(x, y)
#     if S(A,B,C)==S(A,B,M) + S(A,C,M) + S(B,C,M):
#         print("%.3f %.3f"%(M.x,M.y))
#     else:
#         A1,u = tim(B,C,M)
#         B1,v = tim(C,A,M)
#         C1,t = tim(A,B,M)
#         z = min(u,v,t)
#         E=A1 if z==u else (B1 if z==v else C1)
#         print("%.3f %.3f" % (E.x, E.y))



# cau truc sinh vien: ho ten, tuoi, diem
# nhap va xuat
# sx danh sach theo diem giam dan
# sx theo ten tang dan
# in ra ds co diem cao nhat
# from  collections import  namedtuple
# sv = namedtuple('SV',"ten tuoi diem")
# def nhap(fname):
#     f = open(fname,"r")
#     S = []
#     for i in range(int(f.readline())):
#         a,b,c = f.readline().rsplit(None,2) # lay 2 thang cuoi
#         S.append(sv(a,int(b),float(c)))
#     return S
# def xuat(S):
#     for s in S:
#         print("%-20s %5d %6.2f"%(s.ten,s.tuoi,s.diem))
# if __name__ == '__main__':
#     S = nhap("sv.txt")
#     print("Danh sach sinh vien vua nhap")
#     xuat(S);
#     print("Danh sach diem giam dan")
#     S.sort(key = lambda  x : x.diem, reverse=True)
#     xuat(S)
#     print("Danh sach ten")
#     S.sort(key = lambda  x : x.ten.split()[-1])
#     xuat(S)
#
#     print("Danh sach diem cao nhat")
#     print( max(S, key =  lambda x : x.diem))
#
#     print("Tuoi trung binh %f"%(sum([x.tuoi for x in S])/len(S)))
#
#     print("Danh sach sv co diem > 6")
#     T = [x for x in  S if x.diem > 6]
#     xuat(T)