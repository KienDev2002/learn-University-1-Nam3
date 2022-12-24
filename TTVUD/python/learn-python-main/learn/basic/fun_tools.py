


#dujfg list
kteam = [1,2,3,4]
kteam_lst = []
for value in kteam:
    kteam_lst.append(value + 1)
print(kteam_lst)

#dunfg map
# map(func, iterable)
def fun (x):
    return x + 1

kteam = [1,2,3,4]
print(map(fun,kteam))

# Vậy hàm map hoạt động như thế nào? Nôm na là hàm map lấy từng  phần  tử của iterable sau đó dùng gọi hàm func với argument là giá trị mới lấy ra từ iterable, kết quả trả về của hàm func sẽ được yield.
def mymap(func, iterable):
    for x in iterable:
            yield func(x)

#dunfg lambda
print('lambda:')
kteam  = [1,2,3,4]
print(list(map(lambda x: x+1 , kteam)))


# Đôi lúc, việc sử dụng hàm map còn nhanh hơn cả list comprehension
inc = lambda x: x + 1
kteam = [1,2,3,4]
print(inc(x) for x in kteam)
print(list(map(inc,kteam)))




# map(func, *iterable)
# Bạn đọc lưu ý, khi bạn pass vào nhiều container để biến hàm map gọm lại bằng cách packing argument thì các container phải cùng số lượng giá trị (cùng giá trị hàm len). Vì khi có nhiều container pass vào, thì hàm map sẽ cùng một lúc lấy lượt các giá trị của các container.
print('cong 2 list:')
fun = lambda x,y: x + y
kteam_1 = [1,2,3,4]
kteam_2 = [5,6,7,8]
print(list(map(fun,kteam_1,kteam_2)))
# lưu ý là bạn pass vào n container thì bạn cũng phải thiết kế cái hàm nào có thể nhận n argument

print(pow(2,3))
print(pow(3,4))
print(list(map(pow,[1,2,3],[3,4,5])))




# Hàm filter
# Filter có nghĩa là bộ phận lọc. Nghe qua, chắc bạn cũng ít nhiều biết được nó sẽ làm gì rồi.
# Cú pháp hàm này như sau:
# filter(function or None, iterable)

# Lưu ý: không như hàm map, iterable ở đây chỉ là 1 container, không hề có packing argument.

# Hàm filter lấy từng giá trị trong iterable, sau đó gửi vào hàm, nếu như giá trị hàm trả ra là một giá trị mà khi chuyển sang kiểu dữ liệu boolean là True thì sẽ yield giá trị đó, nếu không thì bỏ qua.
# Trường hợp bạn không gửi hàm vào mà  là None, hàm filter lấy từng giá trị trong iterable, nếu giá trị đó chuyển sang giá trị boolean là True thì yield, nếu không thì bỏ qua.
fun = lambda x: x>0
print('\nFilte:')
kteam = [1,2,-4,3,-6,-5,0,9]
print(list(filter(fun,kteam)))
print(list(filter(None,kteam))) # bỏ 0 đi

#list
print('\nList:')
kteam = [1,2,3,6,4,-2,3,-5,-4]
print([x for x in kteam if x>0])

kteam = [0, None, 1, 'Kteam', '', 'Free Education', 69, False]
print(list(filter(None,kteam))) #None: 0 ,None,'' ko show 




# Hàm reduce
# reduce(function, sequence[, initial])
from functools import reduce


# Lưu ý: Hàm reduce không giống như hai hàm trước là trả về một generator expression mà là một giá trị.
# Để đơn giản nhất, chúng ta hãy tạm chưa xét tới parameter initial.
# hàm reduce sẽ lần lượt lấy hai giá trị đầu tiên của sequence (index 0, index 1) và đưa vào hàm function

# Lưu ý: đưa theo thứ tự (index 0, index 1)

# Hàm function này sẽ trả ra một giá trị (ta kí hiệu là A). Sau đó lấy tiếp giá trị thứ ba của sequence (index 2), rồi gửi vào function cũng theo thứ tự (A, index 2), rồi lại lặp lại như thế cho tới khi hết sequence.
print('\nReduce:')
fun = lambda x , y: x + y
kteam = [1,2,3,4]
print(reduce(fun,kteam))


fun_1 = lambda x,y: x*y
kteam = [2,4,5]
print(reduce(fun_1,kteam))


# Nào, giờ chúng ta tới bước khi có argument cho parameter initial.

def fun_2 (x,y): return x + y
kteam = [1,2,3]
print(reduce(fun,kteam))
print(reduce(fun,kteam,10))





