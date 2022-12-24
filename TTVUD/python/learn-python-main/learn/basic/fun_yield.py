# Nhắc lại khái niệm iterables
# Khi bạn tạo  ra một list, bạn có thể truy xuất lần lượt từng giá trị của list đó. Người ta gọi đó là iteration



kteam_lst = [1, 'Kteam', 2]
for value in kteam_lst:
    print(value)


# “kteam_lst” ở đây được gọi là một iterable. Mọi thứ mà bạn có thể dùng cú pháp “for … in …” đều là một iterable. Ví dụ như chuỗi, list, tuple, file,..
# Nhưng iterable này rất thuận tiện cho chúng ta lưu dữ và truy xuất thông tin. Và để được như vậy bạn phải lưu trữ những thông tin đó trong các vùng nhớ máy tính của bạn. Vì lẽ đó, sẽ có trường hợp bạn không cần thiết phải giữ tất cả thông tin cùng một lúc vì nó quá nhiều.



# Giới thiệu generator

# Generator là iterator, một dạng của iterable nhưng khác ở chỗ bạn không thể tái sử dụng. Vì sao lại như vậy? 
# Generator không lưu trữ tất cả các giá trị của bạn ở bộ nhớ, mà nó sinh ra lần lượt


kteam_gen = (value for value in range(3))
for value in  kteam_gen:
    print(value)


# Như đã nói, generator cũng là một iterable, nên nó cũng khá tương tự như khi bạn dùng list hoặc tuple. Nhưng, nếu bạn thử tái sử dụng generator đó
print('\ngenerator:')
# kteam_gen = (value for value in range(3))
for value in kteam_gen:
  print(value)
# Bạn thấy đấy, không có giá trị nào được in ra. Bởi vì khi nó sinh ra giá trị đầu tiên là 0, khi bạn kêu nó sinh tiếp giá trị 1, nó sẽ vứt bỏ giá trị 0 để nhường chỗ cho giá trị 1, và nếu bạn tiếp tục yêu cầu sinh thêm giá trị nó sẽ lại tiếp tục công việc như cũ cho tới khi kết thúc.





# Lệnh yield: đại loại nó return tạm thời thôi, CHO TỚI KHI GẶP LỆNH YIELD và nó sẽ sinh ra giá trị bạn yêu cầu yield.
#  hàm bây giờ được tạm dừng. Bạn cần lưu ý, là chỉ tạm dừng, có nghĩa là nếu lần sau gọi thì nó vẫn tiếp tục chạy sau nó mà ko chạy lại từ đầu 
# Lệnh này cách sử dụng gần giống với lệnh return, tuy nhiên nó khác return ở chỗ trả về một object thì yield sẽ trả về một generator.

print('\nyield:')
# Chúng ta hãy đến với một ví dụ với return sau đó ta sẽ so sánh nó với yield
def square(lst):
    sq_lst = []
    for num in lst:
            sq_lst.append(num**2)
    return sq_lst
kteam_ret = square([1, 2, 3])
print(kteam_ret)
for value in kteam_ret:
    print(value)

    # Và đây là khi sử dụng lệnh yield thay cho return
def square(lst):
    for num in lst:
            yield num**2

kteam_gen = square([1, 2, 3])
for value in kteam_gen:
    print(value)



print('\n\n')

def gen():
    for value in range(3):
            print('yield', value + 1, 'times')
            yield value
for value in gen():
    print(value)

def test():
    yield 'Kteam'
    print('this is the second yield')
    yield 'Free education'
    print('this is the last yield')
    yield 'Long đẹp trai'
    print('Will not return anything')
# CHO TỚI KHI GẶP LỆNH YIELD và nó sẽ sinh ra giá trị bạn yêu cầu yield, hàm bây giờ được tạm dừng. Bạn cần lưu ý, là chỉ tạm dừng, có nghĩa là nếu lần sau gọi,  hàm sẽ tiếp tục chạy ở phần đó không phải chạy lại từ đầu
for value in test():
    print(value)
# Bạn cũng cần lưu ý thêm, nếu không có giá trị yield khi được gọi tiếp thì sẽ yield sẽ không  trả về bất cứ thứ gì, có nghĩa là None object cũng không được trả về.








# Phương thức send

# Đây là phương thức giúp bạn gửi giá trị vào trong một generator.

# Cú pháp:
# generator.send(value)
print('\nyield:')
def gen():
    for i in range(4):
            x = yield i
            print('value sent from you', x)
g = gen() # gán generator này cho biến g
print(next(g)) # gọi hàm next để chạy lệnh yield "x = yield i"
print(g.send('Kteam')) # x vừa nãy khi gán cho biến yield giờ sẽ được gửi giá trị

print(g.send('Free education'))
print(next(g)) # lần này ta không dùng send, mặc định giá trị gửi vào là None




print('\n')
def gen():
    while True:
            x = yield # ở đây ta đang yield None, vì ta không cần thiết sinh giá trị gì ở  đây
            yield x ** 2
g = gen()
next(g) # chạy lệnh yield để ta gửi giá trị cho biến x lần sau
print(g.send(2))
next(g) # tiếp tục chạy yield để có thể gửi giá trị
print(g.send(10))

# Vì sao nên dùng yield
# Tốc độ, khi sử dụng generator, để duyệt các giá trị thì generator sẽ nhanh hơn khi khi bạn duyệt một iterable lưu trữ một lúc tất cả các giá trị

# Bộ nhớ, bạn sẽ phải cân nhắc việc dùng yield khi bạn làm việc với những tập dữ liệu lớn. Lúc đó, bạn sẽ phải xem xét lại xem liệu bạn có cần giữ tất cả các giá trị một lúc không hay chỉ cần sinh ra từng giá trị một để tiết kiệm bộ nhớ.
