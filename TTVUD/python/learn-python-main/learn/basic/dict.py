# Dict(Dictionary) cũng là một container như LIST, TUPLE. 
# Có điều khác biệt là những container như List, Tuple có các index để phân biệt các phần tử thì Dict dùng các key để phân biệt.

# Chắc bạn cũng dùng từ điển tiếng Anh để tra từ vựng rồi nhỉ? Có rất nhiều từ vựng trong đó nhưng mà không từ vựng nào giống nhau. Có chăng chúng chỉ giống nhau về nghĩa? Và đó cũng như Dict(Dictionary) hoạt động trong Python

# Một Dict gồm các yếu tố sau:
# Được giới hạn bởi cặp ngoặc nhọn {}, tất cả những gì nằm trong đó là những phần tử của Dict.
# Các phần tử của Dict được phân cách nhau ra bởi dấu phẩy (,).
# Các phần tử của Dict phải là một cặp key-value
# Cặp key-value của phần tử trong Dict được phân cách bởi dấu hai chấm (:)
# Các key buộc phải là một hash object

dic = {'name': 'Kteam', 'member': 69}
print(dic)
print(type(dic))
dic = {}
print(dic)
print(type(dic))


# Sử dụng Dict Comprehension
dic = {key: value for key, value in [('name', 'Kteam'), ('member', 69)]}
print(dic)
print(type(dic))


# Với dict, ta có 4 cách để khởi tạo một Dict bằng constructor:


# c1
dic = dict()


#c2: Khởi tạo một dict từ một mapping object:dict(mapping)
# Mapping object cũng gần giống so với dict object.
# Một object là Mapping object khi có đủ hai phương thức keys và __getitem__.
# Dict object cũng là một mapping object. Tuy nhiên, không phải mapping object nào cũng là dict object vì dict object không chỉ có hai phương thức keys và __getitem__ và còn nhiều phương thức khác.



#c3: Khởi tạo bằng iterable
# iterable này đặc biệt hơn hơn các iterable mà bạn dùng để khởi tạo List hay Tuple, đó là các phần tử trong iterable phải có 2 value đó chính là cặp key-value.
# Bạn có thể dùng List, Tuple hoặc bất cứ container nào (trừ mapping object) để chứa cặp key-value.

iter_ = [('name', 'Kteam'), ('member', 69)]
dic = dict(iter_)
print(dic)


# Khởi tạo bằng keyword arguments
# Bạn chưa tìm hiểu đến hàm, nên khái niệm keyword arguments vẫn còn rất xa lạ!
# Cứ hiểu đơn giản là giống như việc bạn khởi tạo biến và giá trị rồi đưa cho dict đó giữ giùm.
# Một lưu ý là những biến này không bị ảnh hưởng hoặc ảnh hưởng gì đến các biến bên ngoài

name = 'SpaceX'
member = 696969
# dic = dict(name='Kteam', member=69 , FE = 'kien')
dic = dict(name=name, member=member)

print(dic)


dic = dict(name='Kteam', member=69 , FE = 'kien')
print(dic)


# Sử dụng Phương thức fromkeys
# Công dụng: Cách này cho phép ta khởi tạo một dict với các keys nằm trong một iterable. Các giá trị này đều sẽ nhận được một giá  trị với mặc định là None
iter_ = ('name' , 'number' , 69 , True)
dic = dict.fromkeys(iter_)
dic = dict.fromkeys(iter_,'kien')
print(dic) 




# Lấy value trong Dict bằng key
print('\nvalue của key name la:')
print(dic['name'])






# Thay đổi nội dung Dict trong Python
# Dict là một unhashable object. Do đó, chắc bạn cũng biết ta có thể thay đổi được nội dung nó hay không. Nếu bạn nào nhanh trí, chắc cũng đã biết được cách thay đổi rồi. Tương tự như List thôi!
dic = {'name':'kteam' , 'member':69}
dic['name'] = 'kien' + ' kteam'
print(dic)
dic_2 = {'name': 'How Kteam', 'member': 69}
dic_2['member'] = dic_2['member'] + 1  # neesu int mới cộng đc, str thì ko
print(dic_2)



# Thêm thủ công một phần tử vào dict
# Cách này khá giống với cách bạn thay đổi nội dung của Dict. Khác ở chỗ, bây giờ bạn sẽ sử dụng một key chưa hề có trong dict.
dic = {'name': 'Kteam', 'member': 69}
dic['slogan'] = 'Free Education'
print(dic)















