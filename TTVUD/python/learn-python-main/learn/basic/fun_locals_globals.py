

# kteam = 'How Kteam'
def say_slogan():
    global kteam
    kteam= 'kien'
    print("We are", kteam)
say_slogan()
print(kteam)

# Lưu ý: Biến là đối tượng nên bị ràng buộc bởi điều này. Do đó các HÀM (FUNCTION), LỚP (CLASS) cũng chịu sự ràng buộc này tương tự. Khai báo ở hàm nào thì chỉ dùng ở hàm đó.




# Thay đổi giá trị argument gián tiếp qua parameter
# pass by reference: thay đổi khi bị tác động: đưa bản gốc
# pass by value: đưa giá trị: đưa bản sao


# Đây là pass by value: kiểu như là tham chiếu
num = 69
st = 'How Kteam'
lst = [1, 2, 3]
tup = tuple('Education')

def change(parameter):
    parameter = 'New value'
    print(parameter)
    print('Changed successfully!')

change(num)
change(st)
change(lst)
change(tup)
print('*' * 10)
print('{}\n{}\n{}\n{}\n'.format(num, st, lst, tup))
# Như bạn thấy, không một giá trị nào bị thay đổi vì đó là pass by value.





# đây là pass by reference
lst = ['How Kteam', 1, 2]

def change(parameter):
    parameter[1] = 'New value'
    print('Changed successfully!')
print(lst)
change(lst)
print(lst)






# Sử dụng lệnh global
# Nếu như một biến nằm trong một hàm (như biến kteam trong ví dụ cuối ở phần đầu) thì người ta hay gọi đó là local variable (biến chỉ có hiệu lực trong một hàm nhỏ).
# Cú pháp:                   global <variable>

# Lệnh này như một phép màu mà bạn có thể tạo ra. Giống như bạn có thể  biến một người thành tổng thống Mỹ vậy. Ai trên thế giới này cũng biết. Và như biến, ở nơi nào trong chương trình cũng dùng được.




def make_slogan():
    # khởi tạo với global không có giá trị nhé
    global kteam
    # sau khi khởi tạo xong, ta mới gán giá trị
    kteam = 'How Kteam'
# nhớ là phải chạy hàm nữa
make_slogan()
print(kteam)


# Ở đây Kteam muốn bạn lưu ý một trường hợp là tên biến local trùng với tên biến global.

def make_global():
    global x
    x = 1

def local():
    x = 5
    print('x in local', x)
make_global()
print(x)
local()
print(x)
# Như bạn thấy ở ví dụ trên, biến x trong hàm local đã trùng với biến global x. Tuy nhiên hai biến x này là hoàn toàn khác nhau. Biến x dùng trong hàm local thì có một địa chỉ riêng và một giá trị riêng, còn biến x global thì cũng có một giá trị riêng và một địa chỉ riêng. Thêm nữa, nếu như ta sử dụng biến x ngoài hàm thì Python sẽ tìm tới biến x global chứ không phải là biến x local.
# Lưu ý::BẠN KHÔNG NÊN SỬ DỤNG GLOBAL trừ khi hết cách. Nó giống như hàm eval vậy. Việc sử dụng biến global làm cho chương trình rối, khó kiểm soát cho nên hạn hãy chế tối đa việc sử dụng.



# Giới thiệu hàm locals và globals
# Kết quả trả ra của hai hàm này là một Dict. Với key là tên biến và value là giá trị của biến.
# Lưu ý: Với hàm globals() thì với biến globals có giá trị mới được trả về.
print('\n')
print(local()) # Cái tên hàm nói lên tất cả. Hàm locals cho ta biết được những biến local (những biến được khai báo trong hàm) nằm trong chương trình của chúng ta. 
print(globals()) # Còn globals là hàm giúp chúng ta biết được những  biến global trong chương trình.

