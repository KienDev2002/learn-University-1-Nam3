


#tính số ngày từ d1/m1/y1 -> d2/m2/y2
# def nhuan(y): return y % 400 ==0 or (y%4==0 and y %100!=0)
# def songay(d,m,y):
#     for i in range(1,y): d+=365 + nhuan(i)
#     t = [0,31,28+nhuan(y),31,30,31,30,31,31,30,31,30,31]
#     return d + sum(t[:m])
#
#
# if __name__ == '__main__':
#     d1,m1,y1 = map(int ,input("Ngay bat dau:").split("/"))
#     d2,m2,y2 = map(int ,input("Ngay ket thuc:").split("/"))
#     print(songay(d2,m2,y2) - songay(d1,m1,y1))






# đếm so pt trung phuong. ax^4 + bx^2 +c = 0 (at^2 + bt + c)
# def dem(t):
#     return 0 if t<0 else (1 if t==0 else 2)

# from math import  *
# def pt(a,b,c):
#     if a==0 : return 0 if b==0 else dem(-c/b)
#     else:
#         b/=2
#         d = b*b - a*c
#         if d>0:
#             return dem((-b-sqrt(d))/a) + dem((-b+sqrt(d))/a)
#         else:
#             return 0 if d<0 else dem(-b/a)



def dem(t): return [] if t<0 else ([0] if t==0 else [-sqrt(t),sqrt(t)])
from math import  *
def pt(a,b,c):
    if a==0 : res =  [] if b==0 else dem(-c/b)
    else:
        b/=2
        d=b*b - a*c
        if d>0:
            res =  dem((-b-sqrt(d))/a) + dem((-b+sqrt(d))/a)
        else:
            res = [] if d<0 else dem(-b/a)
        res.sort()
    return res

if __name__ == '__main__':
    # a ,b,c = map(float,input().split())
    # if a==b==c==0: print("vo so nghiem")
    # else: print(pt(a,b,c));
    a ,b,c = map(float,input().split())
    if a==b==c==0: print("vo so nghiem")
    else: print(pt(a,b,c));



# c1: dùng mảng (n)



# c2: tim so fibonacci (de quy 2^n)
# def fibo(n):
#     if(n<2): return 1
#     else: fibo(n-1)+ fibo(n-2)
# if __name__ == '__main__':
#     print(fibo(40))




#c3:dùng dictionary
# d = {}
# def fibo(n):
#     if n in d.keys():
#         return d[n]
#     else:
#         d[n] = 1 if n<2 else fibo(n-1) + fibo(n-2)
#     return d[n]
# if __name__ == '__main__':
#     for n in range(5):
#         print(n,fibo(n))




# c4: dùng dictionary
# def fibo(n):
#     if n<2: return 1,1
#     a,b = fibo(n-1)
#     return b,a+b
# if __name__ == '__main__':
#     for n in range(6):
#         a,b = fibo(n)
#         print(n,b)



# c5
# def fibo(n):
#     if n< 2:
#         return 1,1
#     x,y = fibo(n//2)
#     return (x*x + y*y , 2 *x*y-y*y) if n%2==0 else (x*x+2*x*y , x*x+y*y)
#
# if __name__ == '__main__':
#     for i in range(10):
#         a,b = fibo(i)
#         print(i,a)



# tinh tong day fibo


#class
# class ps:
#     def __init__(self,a = 0,b=1): self.t, self.m = a,b; #constructor
#     def __str__(self): #convert sang string
#         return str(self.t) + "/" + str(self.m)
#     #def __init__(self,s): #hàm tạo từ xâu thành ps
#     #    self.t , self.m = map(int, s.split('/'))
#     def __add__(self, other):
#         return ps(self.t * other.m + self.m * other.t,self.m * other.m)
#
# if __name__ == '__main__':
#     p = ps(2,-3)
#     q = ps(5) # 5 / 1
#     #r = ps(input('r = '))
#     print(p)
#     print(q)
#     # print(r)
#     print(p+q)
