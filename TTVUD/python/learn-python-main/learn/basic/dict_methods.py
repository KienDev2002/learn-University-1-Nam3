

# Phương thức copy
# Công dụng: Giống với phương thức copy trong LIST. Để làm gì thì chắc các bạn cũng có thể suy nghĩ ra.
d = {'team': 'Kteam', (1, 2): 69}
print(d)
d_2 = d.copy()
print(d_2)



# Phương thức clear
# Công dụng: Loại bỏ tất cả những phần tử có trong Dict
d.clear()
print(d)


# Phương thức get
# <Dict>.get(key [,default])
# Công dụng: Trả về giá trị của khóa key. Nếu key không có trong Dict thì trả về giá trị default. Default có giá trị mặc định là None nếu chúng ta không truyền vào.
d = {'team': 'Kteam', (1, 2): 69}
value  = d.get('team')
print(value)
value  = d.get((1,2))
print(value)
value  = d.get((1))
print(value)
value  = d.get((1),'kien')  # neesu kpo co nó sẽ ra gtri mặc định
print(value)


# Phương thức items
#  <Dict>.items()
# Công dụng: Trả về một giá trị thuộc lớp dict_items. Các giá trị của dict_items sẽ là một tuple với giá trị thứ nhất là key, giá trị thứ hai là value.
# Dict_items là một iterable.
d = {'team': 'Kteam', (1, 2): 69}
value = d.items()
print(value)
value = list(d.items())
print(value)
print(value[0])
print(value[1][1])



# Phương thức keys,values
# <Dict>.keys()
# Công dụng: Trả về một giá trị thuộc lớp dict_keys. Các giá trị của dict_keys sẽ là các key trong Dict.
print('\nds key la:')
d = {'team': 'Kteam', (1, 2): 69}
k = d.keys()
v = d.values()
print(k)
print(v)



# Phương thức pop
# <Dict>.pop(key [,default])
# Công dụng: Bỏ đi phần tử có key và trả về value của key đó. Trường hợp key không có trong dict.
# Báo lỗi KeyError nếu default là None (ta không thêm vào).
# Trả về default nếu ta thêm default vào.
d = {'team': 'Kteam', (1, 2): 69}
value = d.pop('team')
print(value)
value = d.pop('t','kien')  # neesu ko có key đó thì nó trả về default
print(value)
print(d)


# Phương thức popitem
# <Dict>.popitem()
# Công dụng: Trả về một 2-tuple với key và value tương ứng bất kì (vấn đề này liên quan đến giá trị của hash của key. Do đó bạn cũng hiểu vì sao key buộc phải là một hash object) trong Dict. Và cặp key-value sẽ bị loại bỏ ra khỏi Dict.
# Nếu Dict là một empty Dict. Sẽ có lỗi KeyError
d = {'team': 'Kteam', (1, 2): 69}
print('\npopitem la:')
value = d.popitem()
print(value)
print(d)


# Phương thức setdefault
# <Dict>.setdefault(key [,default])
# Công dụng: Trả về giá trị của key trong Dict. Trường hợp key không có trong Dict thì sẽ trả về giá trị default. Thêm nữa, một cặp key-value mới sẽ được thêm vào Dict với key bằng key và value bằng default.
# Default mặc định là None
print('\nsetdefault la:')
d = {'team': 'Kteam', (1, 2): 69}
value = d.setdefault('team')
print(value)
value = d.setdefault('what')
print(value)
value = d.setdefault('what_one','kien')
print(value)
print(d)



# Phương thức update
# Công dụng: Phương thức giúp bạn cập nhật nội dung cho Dict.
d = {'team': 'Kteam', (1, 2): 69}
value = d.update(team = 'kien') #update laji casi khóa key là team
d.update(b=2,c=3)  #update thêm key b và c có value la 2 và 3  packing arguments.
print(value)
print(d)
E = {'d': 7, 'e': 6}
d.update(E)  #update 1 E
print(d)






