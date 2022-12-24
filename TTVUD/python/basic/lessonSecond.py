

# for x in A : B, while

# for x in range (10):
#     print(x,end='');
#
#
# b = list(map(float,input().split()));
# for x in b:
#     print(x);



# n = int(input());
# s = 1
# for x in range(1,n+1): s*=x;
# print("n! = " , s);

# n = int(input())
# s =0;
# for x in range(1,n+1):
#     s += x * (n+1-x);
# print(s);


# hàm zip: ghép phần từ này với kia

# a = [1,2,3,4,5];
# b = ['a','b','c'];
# c =list( zip(a,b));
# c =list( zip(a,b,a[::-1])); #ghép 3 thằng a,b,c
# print(c)



# n = int(input());
# a = list(range(1,n+1));
# s = 0;
# for x,y in zip(a,a[::-1]):
#     s+= x * y;
# print(s)




# n = int(input());
# a = list(range(1,n+1));
# s = 0;
# for x,y in zip(a,a[1:]):
#     s+= x * y;
# print(s)




# ktra so nguyen to
# from math import sqrt
# n = int(input());
# m = int(sqrt(n));
# ok = True;
# for i in range(2,m+1):
#     if(n%i==0):
#         ok = False;
#         break;
# print("yes " if ok and n>1 else "no");






# fibonacci
# n = int(input());
# f = [1] * 2; #2 so 1
# for _ in range(n): f.append(f[-1] + f[-2]);
# print(*f[:n]);


# nhap day so va tinh
# s1 tong binh phuong cac phan tu
# s2 tong nhung so chan
# s3 = a1 + (a1 + a2) + (a1 + a2 + a3)


# s1
# a = list(map(int,input().split()));
# b = [x*x for x in a];
# print(sum(b))



# s2
# a = list(map(int,input().split()));
# c = [x for x in a if x%2==0];
# if c ==[]:
#     print("khong co so chan");
# else:
#     print("tong chan:" , sum(c));


# s3, enumerate(): show ra ca index va value.
# k = [1,2,4,6,3,6];
# for i,x in enumerate(k):
#     print(i,x)
#
# a = list(map(int, input().split()));
# s = 0
# for i,x in enumerate(a):
#     s += sum(a[:i+1]);
# print(s);



#nhập dãy số snguyene ktra số có tang dàn ko
# a = list(map(int, input().split()));
# check = True;
# for i in range(len(a)-1):
#     if a[i]>a[i+1]:
#        check = False;
#        break;
# print("day tang" if check else "day ko tang")



# a = list(map(int, input().split()));
# check = True;
# for a,b in zip(a,a[1:]):
#     if a >= b:
#        check = False;
#        break;
# print("day tang" if check else "day ko tang")



# a = list(map(int, input().split()));
# b = [1 for x,y in zip(a,a[1:]) if x>=y];
# print("day tang" if b==[] else "day ko tang")


# đối xứng
# a = list(map(int, input().split()));
# if a==a[::-1]:
#     print("đối xứng");
# else:
#     print("không đối xứng");


# đếm số bộ 3 liên tiếp tạo cấp số cộng
# a = list(map(int, input().split()));
# b = [1 for x,y,z in zip(a,a[1:],a[2:]) if x+z == 2*y];
# print("đếm số bộ 3 liên tiếp tạo cấp số cộng" , sum(b));



# while
# tinh tong cac chu so
# n = int(input());
# s = 0;
# while n >0:
#     s += n%10;
#     n//=10; #chia nguyen
# print(s);
# print(sum(map(int,input())));





# giai pt x^x = a với a thuoc [1,10^10]
# a = float(input());
# L,R = 1,10;
# while R-L > 1e-5:
#     M = (L+R)/2;
#     if M**M > a : R = M;
#     else: L = M;
# print("x = " , L);


# thuật toán chạy nhị phân
# from math import  *;
# # hình tròn tìm điểm trong đường tròn và gần M nhất
# def kc (x,y,z,t): return pow(x-z,2) + pow(y-t,2);
#
#
# if __name__ == '__main__': #hàm main
#     xO,yO,r,xM,yM = map(float,input().split());
#     if kc(xO,yO,xM,yM) <= r*r: print(xM,yM);
#     else:
#         xP,yP = xO,yO;
#         while abs(xP-xM) > 1e-5 or abs(yP-yM)>1e-5:
#             xQ = (xP + xM) /2;
#             yQ = (yP + yM) /2;
#             if kc(xO,yO,xQ,yQ) > r*r:
#                 xM,yM = xQ,yQ;
#             else:
#                 xP,yP = xQ,yQ;
#         print(xM,yM);

#print(float(1e-5))