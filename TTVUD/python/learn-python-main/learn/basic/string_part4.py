


# phương thức chuỗi
a = 'duy Ngo pro'
b = a.capitalize() #chữ cái đầu viết hoa, cái chữ cái sau viết thường
b = a.upper() #viết hoa hết
b = a.lower() #viết thường hết
b = a.swapcase() # thường thành hoa, hoa thành thường
b = a.title() # viết hoa các chữ cái đầu trong 1 từ



# b = a.center(with: chiều rộng căn giữa, [fillchar]: kí tự căn hoặc ko viết gì là khoảng trằng)
b = a.center(15,'*') # để căn giữa
print(b)
b = a.rjust(20,'+') # để căn phải
print(b)
b = a.ljust(20,'-') # để căn trái
print(b)


# mã hóa kí tự
# b = a.encode(encoding='utf-8',errors='strict')
b = a.encode()




# join (cộng chuỗi)
b = a.join(['1','2','3','4'])  # 1 danh sách
print(b)


# thay thể chuỗi, 0 là so lần thay thế
b = a.replace('o','Cuong',2)
print(b)


a='ccckienccc'
# xóa kí tự ở 2 đầu và cuối, ko viết gì là xóa chuỗi trắng
b = a.strip('c')
print(b)
b = a.lstrip('c') # xóa bên trái
print(b)
b = a.rstrip('c') # xóa bên phải
print(a)
print(b)





















