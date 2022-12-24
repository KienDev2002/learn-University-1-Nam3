





my_dic = {'name':'coder', 'content':'programing youtobe channel','city':'singapore'}
print(my_dic)


#khởi tạo dic gán cho biến
my_list2 = dict(name = 'coder', content = 'programing youtobe channel',city = 'singapore')
print(my_list2)


#lấy items qua key, nếu ko có thì key_error
content_in_dict = my_dic["content"]
print(content_in_dict)


#check co key hay khong
if 'name' in my_dic:
    print(my_dic['name'])
else:
    print('no key found')
#bat loi
try:
    print(my_dic['age'])
except KeyError:
    print("no key found")



#add and change item
my_dic['email'] = 'ngokien@gmail.com' #them hoac override dc
print(my_dic)


#delete item, key,value
del my_dic['city']
print(my_dic)


#xoa va lay cai item vua xoa

print(f'poped value : {my_dic.pop("email")}')
print(my_dic)


#popitem():remove ngẫu nhiên trong my_dic hoặc thawgf cusoi cùng vừa thêm vào
my_dic['age'] = 20
print(my_dic)
my_dic.popitem()
print(my_dic)



#loop through key
for key in my_dic.keys():
    print(key , my_dic[key])


#loop over values
for value in my_dic.values():
    print(value)


#loop over keys and valus
for key,value in my_dic.items():
    print(key , value)