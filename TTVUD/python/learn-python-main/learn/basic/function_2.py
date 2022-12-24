
# Positional argument: truyền đối số không có biến
# keyword argument: truyền đối số có biến 


def kteam(a, b):
     pass # lệnh giữ chỗ.


kteam(3,'Free Education') #positional argument.
kteam(a=3, b='Free Education') #keyword argument.

def kteam(a, b):
     print('a', a)
     print('b', b)

kteam(a=3,b=4)
kteam(b=3,a=4)
# Hai cách gọi hàm trên đều tương tự như nhau.


# Một điều nữa là bạn không được phép để positional theo sau (follow) keyword.
def kteam1(a,b,c,d):
     print('a', a)
     print('b', b)
     print('c', c)
     print('d', d)
# kteam(b=3,a=4,8,9)               #lỗi positional không phải theo sau (follow) keyword.
kteam1(5,6,d=3,c=4)
# => keyword phải nằm sau 




# Bắt buộc (force) Positional argument và keyword argument



# Keyword argument
# Trong Python, có một số hàm bắt chúng ta buộc phải pass argument một cách rõ ràng rành mạch như hàm sorted.
print( sorted([3, 4, 1], reverse=True))

# print( sorted([3, 4, 1],True))     lỗi thiếu keyword

# Tèo gọi hàm thì thấy kết quả theo đúng ý mình. Giờ Tèo muốn đổi giá trị của parameter d thành 5. Nên Tèo phải truyền lại các giá trị 2 và 3 cho các parameter b và c.
# Vậy, ta có cách nào không phải truyền lại hai giá trị cho parameter b và c không?
# Có, chính là keyword argument.
#  Teo(1,2,3,5) thay bằng keyword là Teo(1, d=5)



# Python cho phép chúng ta tạo ra các parameter chỉ nhận giá  trị bằng việc pass argument theo kiểu keyword argument.
# Cú pháp
# def function (*, key_arg1, key_arg2):

# # function-block

def kteam(pos_or_key_arg, *, key_arg1, key_arg2):
    print(pos_or_key_arg)
    print(key_arg1)
    print(key_arg2)
kteam(1, key_arg1=2, key_arg2='Kteam') #  "*" chỉ là 1 cú pháp bt, tất cả sau nó là keyword




# Positional argument
# input(prompt=None, /)
# Dấu / chính là một syntax để force parameter prompt trở thành positional only argument. Có nghĩa là bạn chỉ có thể pass argument cho parameter prompt theo kiểu positional. Chính xác thì dấu / sẽ biến các parameter đứng trước nó thành positional only argument



