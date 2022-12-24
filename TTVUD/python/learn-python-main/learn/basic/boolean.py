

# toán tử đc ưu tiên hơn so với các logic  "=="
print(241 == 141 + 100)


# Python so sánh các kí tự với nhau bằng cách đưa chúng về dưới dạng số bằng hàm ord. Bạn có thể tham khảo giá trị của nó trong ASCII Table.


print( ord('A'))
# print(ord('ABC')) : lỗi
# Khi bạn so sánh bằng các toán tử ==, >=, <= thì Python sẽ so sánh hết các phần tử.
# Còn nếu bạn dùng các toán tử như >, <, != thì nhiều lúc Python sẽ không cần phải đi hết các giá trị iterable. Nếu như ở vị trí i nào đó mà đã hai giá trị không bằng nhau thì nó sẽ dừng lại.


# Thế nào là bằng (==)?
# Bằng là toán tử so sánh khi nói về mặt giá trị.


# Thế nào là là (is): là các đối tượng với nhau
# Là (is) trong trường hợp này là liên từ diễn giải định nghĩa, tính chất của một sự vật/sự việc/con người.



lst = [1, 2, 3]
lst_ = [1, 2, 3]
print(lst==lst_)  # trả về true
print(lst is lst_) # trả về false
print(id(lst))
print(id(lst_))
lst_ =  lst  #cùng quản lý 1 vùng nhớ
print(lst==lst_)  # trả về true
print(lst is lst_) # trả về true
print(id(lst))
print(id(lst_))

# => Khi so sánh hai giá trị (đối tượng) bằng toán tử == thì Python sẽ so sánh bằng giá trị của chúng.
#  Còn nếu so sánh bằng toán tử is thì Python sẽ lấy giá trị của hàm id để so sánh.

# Các số từ -5 đến 256 hoặc là một số chuỗi có số kí tự dưới 20 thì các biến có cùng một giá trị sẽ có cùng một giá trị trả về từ hàm id.
a = 699
b = 699
print('\n699:')
print(id(a))
print(id(b))
print(a == b) #False vì vượt quá 255, còn nếu so sánh 2 số đó luôn không lưu biến thì là true
print(a is b) #False vì vượt quá 255, còn nếu so sánh 2 số đó luôn không lưu biến thì là true



# Mọi giá trị khi chuyển về Boolean đều là True trừ một số trường hợp sau

# Số 0
# None
# Rỗng

print(bool(0))
print(bool(None))
print(bool(''))
print(bool([]))
print(bool(()))
print(bool(set()))
print(bool({}))


print (bool(1))
print (bool('abc'))
print (bool([1, 2, 3]))

# Syntaxnic sugar cho việc so sánh trong Python
# Nhưng với Python, bạn có thể làm thế này. không cần and và or
# 1 < a < 6
# b = -4
# b < -3 < -1 < 0 < a < 6 # thậm chí là dài như thế này
# k = 4
# k == 3 or k == 4 or k == 5
# # Tuy nhiên, bạn cũng có thể
# k in (3, 4, 5) # nên dùng () hơn là [] hoặc thứ gì khác

# VD:
print('kq:', end=' ')
print(4<5<6)