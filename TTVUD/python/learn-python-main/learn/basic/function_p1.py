# Cú pháp:

# def <function_name>(parameter_1 [: <kiểu dữ liệu gợi ý của parameter_1>], parameter_2 [: <kiểu dữ liệu gợi ý của parameter_2>], .., parameter_n [: <kiểu dữ liệu gợi ý của parameter_n>]) [-> <kiểu dữ liệu trả về được gợi ý> ]
#     function-block



def  kteam():
    pass  #để khi dùng hàm ko viết gì trong hàm
print(kteam())




def kien():
    print('hello kien')
print(kien())


def kien1(txt):
    print(txt)

print('kien cntt2')

#parameter: tham số hình thức: chính là tham số của hàm – là tên các biến sẽ được sử dụng trong hàm. 
#argument: tham số thực sự: là đối số, tức là giá trị mà ta truyền cho parameter.



# Giá trị mặc định của parameter (Default argument)
def kteam(name, greating='Hi'): #default: giá trị mặc định phải nằm sau đối
     print(greating, name + '!')
kteam('Kteam')
kteam('SpaceX')
kteam('SpaceX', 'Hello')
# Khi bạn đưa default argument cho các parameter, phải để các parameter có default argument ở sau cùng.



kter = 'kter'
def kteam(age , txt = kter):
    print(txt)
    print(age)
kteam(10,'k9')  # thay đổi giá trị mặc định khi có đối thứ 2
kteam(20)


def f (kteam = []):
    kteam.append('F')
    print(kteam)
f()
f()
f()
f()






























