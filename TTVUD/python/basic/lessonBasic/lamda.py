
# ghép 2 hcn => 1 hình vuông
from cmath import sqrt
import math


# a,b,c,d = map(float,input('nhap 2 hinh chu nhat: ').split());
# if a < b: a,b = b,a;
# elif c < d : c,d = d,c;
# if a==c == b + d:
#     print('yes');
# else:
#     print('no');



# a,b,c,d,e,f= map(float,input('nhap 3 hinh chu nhat: ').split());
# x = max(a,b,c,d,e,f);
# if x==sqrt(a*b + c*d + e *f):
#     print('yes');
# elif(x==b+c==b+e==d+f):
#     print('yes');
# elif(x==a+c==a+e==d+f):
#     print('yes');
# else:
#     print('no');



# a= range(1,10);
# print(*a)
# print(a)
# a= range(1,10,2); #cách nhau 2 dv
# print(*a)

# a = range(10,1,-1); #chạy từ 10 -> 2
# print(*a)

# a = range(10);
# print(*a)

# a = range(10);
# print(a[3]*a[1])

# a = list(range(10));
# a.append(2);

# print(*a)
# print(a)#show ra mang so
# print(a[2] * a[3])

# b = a[4:8]
# print(b)
# print(*b)


# b = a[:8]
# print(b)
# print(*b)


# b = a[2::2] #từ a[2] - a[4] - a[6] //buoc nhay index la 2
# print(b)
# print(*b)


# c = a[::-1]; #dao day a
# print(c)
# print(*c)


# d = input().split();
# d = map(int,d);
# # d = list(d);
# # print(*d)
# print(d[0]) #list moi truy vấn đc index map ko đc.


# function
# def f(x):
#     return 1 - x%2;
#
# def numberanode(x):
#     if x>0 :
#         return 1;
#     return 0
# a = [4,5,3,2,-5,6,-8];
# print('so so chan: ',list(map(f,a)));
# print('so so chan: ', sum(map(f,a)));
# print('so so duong', list(map(numberanode,a)))
# print('so so duong', sum(map(numberanode,a)))
# print('so so duong', sum(map(lambda x: 1 if x > 0 else 0 ,a))) #Hàm Lambda là một hàm ẩn danh nhỏ
#
#
# #Filter the array, and return a new array with only the values equal to or above 18
# # b = filter(numberanode,a);
# b = filter(lambda x:  True if x > 0 else  False,a);
# # print('cac so duong la: ',*b);
# for x in b:
#     print(x);
#
# # len
# mylist = ["apple", "banana", "cherry"]
# x = len(mylist)
# print(x)
# # sort
#
# b = a.sort();
# print(*a)
#
# b = a.sort(reverse=True);
# print(*a)
#
#
#
#
# # reduce
# # python code to demonstrate working of reduce()
#
# # importing functools for reduce()
import functools
#
# # initializing list
lis = [1, 3, 5, 6, 2]
# # using reduce to compute sum of list
# print("The sum of the list elements is : ", end="")
# print(functools.reduce(lambda a, b: a+b, lis))
#
# # using reduce to compute maximum element from list
print("The maximum element of the list is : ", end="")
print(functools.reduce(lambda a, b: a if a > b else b, lis))