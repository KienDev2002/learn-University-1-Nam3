


# Packing chính là việc đóng gói toàn bộ dữ liệu vào một vùng chứa duy nhất. 
# Còn unpacking thì ngược lại, nó sẽ lần lượt bê ra các giá trị từ một vùng chứa nào đó.



#unpaking
def kteam(k, t, e, r):
    print(k)
    print(t, e)
    print('end', r)

lst = ['123', 'Kteam', 69.96, 'Henry']
kteam(lst[0], lst[1], lst[2], lst[3])

# TH trên ko đc tối ưu nên ta dùng cách unpaking
# Khi bạn sử dụng *, bạn không chỉ có thể unpack được các List mà bên cạnh đó bạn có thể unpack các container khác như Tuple, Chuỗi, Generator, Set, Dict (chỉ lấy được key).
kteam(*lst)




# Lưu ý:
print('\n\n')
# Pass argument bằng cách unpacking argument như thế này là đang truyền vào dưới dạng positional argument. Hãy cẩn thận sử dụng kĩ thuật này với những hàm có parameter dạng keyword-only argument.
def a(k,t,e,r,*, s, d):
    print(k,t,e,r,s, d,end=' ')
# a(*('a', 'b'))   #sẽ bị lỗi 
a(*lst,s=('a','b'),d='c')




# Packing chính là việc đóng gói toàn bộ dữ liệu vào một vùng chứa duy nhất. 
# Packing arguments với *: lys thuyết trong kteam
print('\n\n packingL')
def kteam(*args):  #args (viết gọn của arguments)
    print(args)
    print(type(args))
kteam('Kteam', 69.96, 'Henry')
kteam(*(x for x in range(7)))

def kteam(*args):
    print(args)
    print(type(args))
kteam('Kteam', 69.96, 'Henry')
kteam(*(x for x in range(7)))


# Lưu ý:

# Bạn không nên nhầm lẫn việc này với việc force keyword-only argument
# Không được phép để 2 parameter cùng làm nhiệm vụ packing argument trong một hàm
def kteam(*args,kter):  
    print(args)
    print(kter)
    print(type(args))
# kteam(*(x for x in range(7)),'kien')  #lỗi: vi phạm cái lưu ý ở trên
kteam(*(x for x in range(7)),kter = 'kien') # phải để keyword không thể positional




# Ở những ví dụ trên các bạn có thể thấy Kteam sử dụng biến packing có tên là args
# . Đó không phải là ngẫu nhiên mà là một quy ước nhỏ của các Pythonist với nhau. Thường người ta sẽ sử dụng biến có tên là args (viết gọn của arguments) để làm biến packing.





# Unpacking arguments với **

# Ta thử unpacking một Dict chỉ với một dấu *
print('\n\nunpacking với dict chỉ lấy đc key thôi *:')
dic = {'name': 'Kteam', 'member': 69}
def kteam(a, b):
    print(a)
    print(b)
kteam(*dic)

# Với Dict, thì nó phức tạp hơn một xíu khi mỗi  phần tử là một cặp key và value. Vậy nên một dấu * là không đủ nội công để unpack hết được các giá trị. Do đó ta phải nhờ đến một cặp **.
print('\n\nunpacking với dict ** nhưng tham số hình thức và key phải giống nhau:')
dic = {'name': 'Kteam', 'member': 69}

def kteam(name, member): #parameter với key là giống nhau. không là lỗi
    print(name)
    print(member)
kteam(**dic)






# Packing arguments với **
print('\n\npacking với **:')
#  Khác với dấu * là gói những positional argument thì ** lại gói các keyword argument. Và đương nhiên, nó sẽ gói trong một Dict. Nếu không truyền gì vào sẽ là một dict rỗng
def kteam(**kwargs): #Tên biến kwargs (viết gọn của keyword arguments) cũng là một quy ước đặt tên.
    print(kwargs)
kteam(name='Kteam', member=69)



def kteam(**kwargs):
    for key, value in kwargs.items(): # phương thức items của kiểu dữ liệu Dict
        print(key, '=>', value)
kteam(id=3424, name='Henry', age=18, lang='Python')
# Lưu ý: bạn không được phép bỏ các positional parameter sau biến packing mà có ** giống như với *.
#  positional phải nằm trước

def kteam (**kwargs):
    for key ,value in kwargs.items():
        print(key,'=>',value)
kteam(name = 'Kteam',member  = 69)

def best_function_ever(*args, **kwargs):
# việc còn lại của bạn là thỏa sức biến tấu
   pass









