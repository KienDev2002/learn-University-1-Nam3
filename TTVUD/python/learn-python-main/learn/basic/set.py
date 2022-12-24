

# Set là một container, tuy nhiên không được sử dụng nhiều bằng LIST hay TUPLE.
# set không quan tâm đến vị trí của phần tử nằm trong set. Nên, việc indexing và cắt set trong Python không được hỗ trợ

# Một Set gồm các yếu tố sau:

# Được giới hạn bởi cặp ngoặc {}, tất cả những gì nằm trong đó là những phần tử của Set.
# Các phần tử của Set được phân cách nhau ra bởi dấu phẩy (,).
# Set không chứa nhiều hơn 1 phần tử trùng lặp
# Set chỉ có thể chứa các hashable object nhưng chính nó không phải là một hashable object. Do đó, bạn không thể chứa một set trong một set.


set_1 = {6,9}
print(set_1)
print(type(set_1))


set_1 = {'kien'}
print(set_1)




set_1 = {('kien',69) , (1,2,3)}
print(set_1)



# lỗi: vì set ko chứa unhashtable là list và thằng chính nó
# set_1 = {['kien',69] , [1,2,3]}
# print(set_1)





set_1 = {'kien',69}
print(set_1)


# set ko đc tạo rỗng vì nó sẽ trở thành kiểu dữ liệu dict
set_1 = {}
print(set_1)
print(type(set_1))


set_1 = {1,1,1}
print(set_1)
print(type(set_1))



#set trong for
set_1 = {i for i in range(10)}
print(set_1)



# Sử dụng constructor Set: ddeer tách hết ra
# Cú pháp:
# set(iterable)
# Công dụng: Giống hoàn toàn với việc bạn sử dụng constructor List.
#  Khác biệt duy nhất là constructor Set sẽ tạo ra một Set.

set_1 = set('kien')
set_2 = set('kkkkkkkkk')
print(set_1)
print(set_2)  # chỉ ra đúng 1 k


# Một số toán tử với Set
#toán tử in
print((1,2) in {(1,2),3}) #trả về true nếu tuple 1 , 2 nằm trong sau in



#toán tử trừ: Kết quả trả về là một Set gồm các phần tử chỉ tồn tại trong Set1 mà không tồn tại trong Set2
print('toán tử trừ: ')
print({1,2,3} - {2,3})
print({2,3} - {2,3})  # set rỗng
print({2} - {2,3}) # set rỗng



# Toán tử &
# Cú pháp:
# <Set1> & <Set2>
# Công dụng: Kết quả trả về là một Set chứa các phần tử vừa tồn tại trong Set1 vừa tồn tại trong Set2
print('toán tử &: ')
print({1,2,3} & {2,3})
print({2,3} & {2,3})  
print({2} & {2,3}) 



# Toán tử |
# Cú pháp:
# <Set1> | <Set2>
# Công dụng:  Kết quả trả về là một Set chứa tất cả các phần tử tồn tại trong hai Set
print('toán tử |: ')
print({1,2,3} | {2,3})
print({2,3} | {2,3})  
print({2} | {2,3}) 


# Toán tử ^
# Cú pháp:
# <Set1> ^ <Set2>
# Công dụng:  Kết quả trả về là một Set chứa tất cả các phần tử chỉ tồn tại ở một trong hai Set
# lấy tất cả các set xong trừ đi set chung dùng dấu | - &
print('toán tử ^: ')
print({1,2,3} ^ {2,3})
print({2,3} ^ {2,3})  
print({2} ^ {2,3}) 






#methods 

print('phương thức ')
a = {1,2,4,5}
a.clear()  # lamf sạch ra set rỗng
print(a)


#pop lấy ra và xóa ptu ban đầu,# nếu set rỗng thì sẽ bị lỗi
b = {1,2,4,5}
b.pop()  # kết quả trả về là 1 gtri đầu tiên đc lấy ra từ set đồng thời loại bỏ giá trị đó trong set ban đầu
print(b)  



# xóa ptu trong set, nếu ptu ko trong set sẽ bị lỗi
b = {1,2,4,5}
b.remove(2)
print(b)  


# discard: giống với remove chỉ khác là nếu ko có ptu ý thì nó sẽ vẫn chạy đc

b = {1,2,4,5}
b.discard(6)
print(b)  



# copy
b = {1,2,4,5}
c = b.copy()
print(c)  


#add: thêm value và trong set nếu có rồi thì thôi
b = {1,2,4,5}
print(id(b))
b.add(0)
b.add(3)
print(id(b))
print(b)  


# Set không phải là một hash object
#  ta đã thay đổi nội dung của set nhưng id của set vẫn là id ban đầu
a = {1,2}
b = a.copy()
b.clear()
print(b)
print(a)



# <Set>.update(iterable_1, iterable_2,…)
# Công dụng: Lần lượt thêm các phần tử của các iterable vào trong set (nếu chưa có sẵn).

a = {1, 2, 3}
a.update('abc')
print(a)
a.update({23})
print(a)
a.update('def', [1, 2, 3], (4, 5, 6))
print(a)


# Các phương thức xác thực


# Công dụng: Trả về True nếu toàn bộ các phần tử của Set đều thuộc OtherSet (Set là tập hợp con của OtherSet). Ngược lại trả về False.
a = {'1', 2, '3', 5, '5'}
b = {'1', '3', '5'}
print(b.issubset(a)) #b có là con a ko

# Lưu ý: Một set trống luôn luôn là tập hợp con của một set khác
a = {1, 2}
print(set().issubset(a))



# <Set>.issuperset(OtherSet)

# Công dụng: Trả về True nếu toàn bộ các phần tử của OtherSet đều thuộc Set (OtherSet là tập hợp con của Set). Ngược lại trả về False.
a = {'1', 2, '3', 5, '5'}
b = {'1', '3', '5'}
print (a.issuperset(b))





