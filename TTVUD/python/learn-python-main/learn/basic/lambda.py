
# Ta có cú pháp sau: Trong kteam có lý thuýete
# lambda argument_1, argument_2, …, argument_n  (các đối số) : expression(khối lệnh cần thực hiên)

a = lambda x,y:x + y
print(a(3,4))
print(a)

#  default argument
def power_a(x, a = 2):
    return x ** a
print(power_a(2))
print(power_a(2, 3))

# Điều đó cũng có thể làm được với lambda
power_a = lambda x, a=2: x ** a
power_a(2) #4
power_a(2, 3) #8



#  lưu ý thêm là lambda cũng phân biệt global và local 
def kteam():
    mem = lambda x: x + ' is a member of Kteam'
    return mem # trả về một hàm nặc danh
call_mem = kteam() # lấy biến call_mem giữ hàm nặc danh
print(call_mem('Long')) # giá  trị chuỗi được đưa vào cho biến x
print(call_mem(call_mem('Giau')))
print(call_mem)


# Vì sao dùng lambda
kteam_lst = [lambda x: x**2 , lambda x: x**3 , lambda x:x**4]
print(kteam_lst[0])
print(kteam_lst[0](2))
print(kteam_lst[-1](4))

for fun in kteam_lst:
    print(fun(3))

#neesu dung def thì như này
def f1(x):
    return x**2

def f2(x):
    return x**3
def f3(x):
    return x**4

kteam_lst = [f1,f2,f3]
print(kteam_lst[0](3))
print(kteam_lst[-1](3))

for fun in kteam_lst:
    print(fun(3))

# Không chỉ mình list, bạn có thể sử dụng lambda với dictionary

key = 'Kteam'
print({'Google': lambda: 'Goooooooog',
'YouTube': lambda: 'Youuuuuuuuu',
'Kteam': lambda: 'Free Education'}['Google']())
# Lưu ý: Bạn để ý ví dụ trên, phần argument của lambda ta để trống, điều này hoàn toàn đúng cú pháp vì phần argument là optional (không bắt buộc) nhưng phần expression bắt buộc phải có một expression.



# Câu điều kiện cho lambda
# Rõ ràng bạn đã thấy, lambda chỉ nhận một expression, do đó, bạn không thể chèn câu lệnh điều kiện như bình thường được mà phải theo một cách khác.
# if a:
#     b

# else:
#     c

# # Thì có thể viết dưới dạng expression với 2 cách như sau
# b if a else c
# (a and b ) or c
print('\nGTLN:')
find = lambda x,y: x if x > y else y
print(find(5,6))
print(find(9,3))

#c1:
print('\n Ước của 2 và 3:')
check = lambda x: ( 1 if x%3==0 else 0) if x%2==0 else 0
print(check(4))
print(check(6))
print(check(5))
#c2:
check = lambda x: (1 if not (x % 3) else 0) if not (x % 2) else 0
print(check(6)) 
print(check(4)) 
print(check(12)) 


# Lambda chồng lambda
#c1: def
def kteam (first_string):
    return lambda second_string: first_string + second_string
slogan = kteam('How kteam')
print(slogan('free education'))
#c2: lambda
kteam = lambda first_string: (lambda second_string: first_string + second_string)
slogan = kteam('How kteam')
print(slogan('Free Education'))
# hoặc
print((lambda first_string: (lambda second_string: first_string + second_string))('How kteam')('Free education'))






