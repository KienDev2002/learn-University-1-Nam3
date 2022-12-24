

# ngoặc vuông
# chia ra thành các index
a = 'how kteam free education'
#cắt khoảng trắng ra thành 2 index , 0 và 1
b = a.split(' ',1) # cắt ra 2 lần index 0 và 1 n trở thành list
b = a.rsplit()
print(b)


# ngoặc tròn, cắt chữ k
b = a.partition('k')
b = a.rpartition('k')  #cắt các chữ bên phải chữ k sang index sau
print(b)

#đếm kí tự , từ vị trí 0 đến vị trí 10
b  = a.count('e',0,14)
print(b)

# strartswitch: trả về true nếu kí tự đó xuất hiện đầu tiên từ vị trí thứ i đến j, nếu ko có i la tư 0, false ngược lại
b = a.startswith('k',4,8)
print(b)


# endswitch: trả về true nếu kí tự đó xuất hiện cuối cùng từ vị trí thứ i đến j, nếu ko có i la tư 0, false ngược lại
b = a.endswith('n',0,20)
b = a.endswith('n',0,25)
print(b)

#tìm kiếm từ trả về vị trí index đầu tiên của kteam là vị trí ở k
# nếu ko tìm đc nó ra -1
b = a.find('kteam')
b = a.rfind('kteam') # từ phải qua



# index:Nếu ko tìm đc ra lỗi
b = a.index('k')  #chạy đc vì có kí tự k
# b = a.rindex('y')  # lỗi
print(b)


# trả về bool Có phải là chuỗi viết thường hay ko
b  = a.islower()
print(b)

# trả về bool Có phải là chuỗi viết hoa hay ko
b = a.isupper()
print(b)

#trả về bool có phải là số ko
b = a.isdigit()
print(b)

#trả về bool có khoảng trắng ko
b = a.isspace()
print(b)






















