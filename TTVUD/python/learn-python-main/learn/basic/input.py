
#lý thuyết: nằm trên team
# bản chất là nó trả ra 1 chuỗi cho dù nhập số hay list hay gì 
name = 'kien'
print('xin chao' , name)

# Parameter prompt là một parameter tùy chọn. Bạn có thể nhập hoặc không vì nó đã có giá trị mặc định là None.
input('string') # hợp lệ
# input(prompt='string') # không hợp lệ
# Nếu prompt khác None, có nghĩa là bạn gửi cho prompt một giá trị. Thì giá trị này sẽ được in ra mà không có kí tự newline đi kèm trước khi đọc giá trị nhập vào.


# ko có đổi
value = input()
print('first vale is =>',value)

# có đối
next_value = input('please enter one more value: ')
print('The second value is =>', next_value)


int_num = input('Enter an integer: ')
float_num = input('Enter a float: ')
lst = input('Enter a list: ')
tup = input('Enter a tuple: ')
set_ = input('Enter a set: ')
dict_ = input('Enter a dict: ')

# print out output: lúc nào cũng là kiểu string
print('Type of int_num', type(int_num))
print('Type of float_num', type(float_num))
print('Type of lst', type(lst))
print('Type of tup', type(tup))
print('Type of set_', type(set_))
print('Type of dict_', type(dict_))




value = input('Enter something => ')
print('You just entered', value)
print('__repr__ method: %r' %value) # nếu nó có thì  sẽ show ra đc value và nằm trong nháy đơn, còn không thì thì chuỗi nhận đc từ hàm input là rỗng , số kí tự bằng 0
























