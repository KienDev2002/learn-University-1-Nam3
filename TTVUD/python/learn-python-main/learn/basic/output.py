

# print(*objects, sep=' ', end='\n', file=sys.stdout, flush=False)

# *objects

# * chính là packing argument. Ở đây hiểu nôm na sẽ là nó sẽ gom lại các argument của bạn lại thành một Tuple.
packing = 1, 2, 3, 4
print(packing)






#sep: đại loại nó là để nối chuỗi, khoảng trằn hoặc gì đó

# Giá trị mặc định của parameter này là một khoảng trắng. Khi các argument bạn ném vào cho hàm print để hàm print in ra nội dung, như đã biết là nó sẽ được gói vào một Tuple. Các giá trị trong Tuple sẽ được nối với nhau bằng parameter sep.
# Lưu ý: Khi truyền giá trị vào cho parameter theo cách keyword argument thì sẽ không bị packing. Nghĩa là sẽ không bị gói vào trong giá trị của parameter object.

print('Kteam', 'Python', 'Course') # sep mặc định là 1 khoảng trắng
print('Kteam', 'Python', 'Course', sep='---')
print('Kteam', 'Python', 'Course', sep=' ' )



# end (kết thúc bằng): đại loại mình thay đổi đối end thành end khác  khi print khác nó sẽ ko xuống dòng mới


# Đó là nhờ parameter end. Nó sẽ tự thêm một kí tự newline (\n) vào cuối để có thể đưa con trỏ xuống dòng mới thay vì bạn phải tự thêm \n như một số ngôn ngữ lập trình khác (một số ngôn ngữ lập trình có hỗ trợ thêm phương thức giúp xuất nội dung và tự động xuống dòng)
# Và đương nhiên, chúng ta cũng có thể thay đổi giá trị của parameter này.
print('a line without newline', end=' ')
print('kien')



from time import sleep # nhập hàm sleep từ thư viện time

print('start....')
sleep(3) # dừng chương trình 3 giây
print('end...')
from time import sleep # nhập hàm sleep từ thư viện time

print('start....', end='') # in ra nội dung và kết thúc bới một chuỗi  rỗng
# sleep(3) # dừng chương trình 3 giây
print('end...')

from time import sleep # nhập hàm sleep từ thư viện time
# Vì chuỗi 'line 1\n' có kí tự newline nên chuỗi đó được xuất ra. Còn chuỗi 'line 2' thì không nên vẫn nằm trong bộ nhớ đệm.
print('line 1\n', 'line2', end='')
# Quy trình sẽ là nạp chuỗi line 1 vào bộ nhớ đêm, nạp tiếp chuỗi line 2 vào bộ nhớ đệm, thấy chuỗi line 2 có kí  tự newline, xuất những gì có trong bộ nhớ đệm ra. Sau đó đợi 3 giây và rồi xuất nội dung còn lại.
print('line 1', 'line 2\n', end='')
sleep(3) # dừng chương trình 3 giây
print('end...')






# file
# Mặc định hàm print sẽ ghi nội dung vào file sys.stdout. Cũng nhờ vậy, bạn mới thấy được nội dung trên shell. Đương nhiên, dựa vào đây, ta cũng có thể sử dụng hàm print như là phương thức write trong việc ghi file.

with open('printtext.txt', 'w') as f:
    print('printed by print function', file=f)
with open('printtext.txt') as f:
     f.read()


# flush
# Parameter cuối cùng - flush. Giá trị mặc định giá trị là False. Liên quan khá nhiều đến parameter end lúc nãy thế nên ta hãy quay lại ví dụ lúc nãy.


from time import sleep # nhập hàm sleep từ thư viện time

print('start...', end='')
sleep(3) # dừng chương trình 3 giây
print('end...')
# => Sau 3 giây chương trình mới có kết quả

# khác với ở trên, show ra ngay từng thằng 1 vì có flush = True
from time import sleep # nhập hàm sleep từ thư viện time

print('start...', end='', flush=True)
sleep(3) # dừng chương trình 3 giây
print('end...')
# Kết quả bây giờ vẫn vậy, nhưng quá trình xuất kết quả có chút khác biệt. Bạn ngay lập tức nhìn thấy nội dung dòng print đầu tiên. Đó là nhờ parameter flush. Nếu là True, nó sẽ yêu cầu bộ đệm xuất những gì có trong bộ đệm ra.


# sự khác nhau py 3x với py 2x (lý thuyết trong kteam) 


from time import sleep

your_name = "Henry"
your_great = "Hello! My name is "

for c in your_great + your_name:
    print(c, end='', flush=True)
    sleep(0.1)
print()




