

# Kiểu dữ liệu range (dãy số)
# Bạn gặp kiểu dữ liệu này suốt các phần liên quan đến comprehension hoặc là liên quan đến iterator object.


# Cách khởi tạo thứ nhất
# Cú pháp:  
# range(stop): có hỗ trợ index

from typing import cast

k = range(5) #0,1,2,3,4
print(k[0])
print(k[1])
print(k[2])


# Cách khởi tạo thứ hai
# Cú pháp:
# range(start, stop, step): step là bước nhảy
# in ra là: start , stop-step
# Với cú pháp này, ta sẽ tạo một dãy số bắt đầu bằng start và kết thúc là stop – 1. Dãy số này là một cấp số cộng với công sai là 1.
print(list(range(2,5,2))) #2 đến 5 bước nhảy là 2
print(range(2,5,2)) #2 đến 5 bước nhảy là 2
print(list(range(4,1,-1)))#4 về 2
print(list(range(2,-3,-1))) # 2 về -2


print(99999999999999 in k)
# Range là một lớp được thiết kế riêng để lưu giữ những dãy số. Vậy nên nó đã được những kĩ sư Python sử dụng các thuật toán để có thể có được sự linh hoạt này.
# Mỗi lần bạn lấy một giá trị trong một đối tượng thuộc hàm range thì đối tượng này sẽ lấy các giá trị của start, stop, step và một vài thứ khác để tính toán và sinh ra một con số.




# Sử dụng range để duyệt một List, Tuple, Chuỗi
# Chúng ta sử dụng một dãy số để dùng indexing lấy các giá trị trong một List, Tuple hoặc Chuỗi.
# Chúng ta có hàm range sinh ra một dãy số.
# Kết hợp chúng lại, ta có thể duyệt một List, Tuple hoặc Chuỗi:
lst = [2,(1,2,3),{'abc','xyz'}]
for i in range(len(lst)):
    print(lst[i])












# Sự khác nhau giữa sequence scan và indexing scan
# Trong bài trước, bạn thấy rằng ta không cần dùng tới hàm range vẫn có thể duyệt hết các phần tử của một List. Vậy điều gì khiến chúng ta đôi lúc phải dùng tới hàm range để xử lí một List?
# Đó là khi ta cần update (cập nhật) List

# Đầu tiên là sequence scan: Th value copy giá trị: tham trị
lst = [1,2,3]
for value in lst:   #1,2,3
    print(value,end=' ')


# Còn đối với indexing scan: Th value trỏ vào giá trị cùng nhớ: tham chiếu: kiểu mượn thằng kia dùng
lst = [1,2,3]
for value in range(len(lst)): # 0,1,2
    print(value,end=' ')









# Comprehension: lý thuyết trong kteam

# Có lẽ bây giờ những comprehension không còn phức tạp với các bạn nữa.
# Comprehension là một công cụ rất hiệu quả của Python để xử lí rất nhiều việc mà chỉ cần một dòng.
# Bên cạnh đó. Người ta còn so sánh những comprehension và những đoạn code với chức năng tương tự thì comprehension có tốc độ nhanh hơn.
#cú pháp:  [ output-expression for-statement optional-predicate ]
# coi ['--'.join((a.capitalize(), b.upper() + c.lower())) là khối lệnh trong for
lst = ['--'.join((a.capitalize(), b.upper() + c.lower())) for a, b, c in [('how', 'kteam', 'EDUCATION'), ('chia', 'sẻ', 'FREE')]] # bỏ trống optional-predicate
# ['How--KTEAMeducation', 'Chia--SẺfree']
print('\n',lst)

# hoặc c2: 

lst = []
for a,b,c in [('how', 'kteam', 'EDUCATION'), ('chia', 'sẻ', 'FREE')]:
    a = a.capitalize()
    b = b.upper() 
    c = c.lower()
    lst.append('--'.join((a,b,c)))
    # lst.append('--'.join((a+b,c)))

print(lst)

# => c1 sẽ có tốc đọ nhanh hơn so với c2

lst = {key:value + 1 for key, value in (('Kteam', 69), ('Tèo', 50), ('Tũn', 14), ('Free Education', 93)) if value % 2 != 0}
# {'Kteam': 70, 'Free Education': 94}
print(lst)

# hoăc
dic = {}
for key, value in (('Kteam', 69), ('Tèo', 50), ('Tũn', 14), ('Free Education', 93)):
     if value % 2 != 0:
         dic[key] = value + 1
print(dic)








# Giới thiệu hàm enumerate
student_list = ['Long', 'Trung', 'Giàu', 'Thành']
for student in student_list:
     print(student)

# có số thức tự
for student in range(len(student_list)):
     print(student , '=>',student_list[student])

# python cũng hỗ trợ 1 hàm sẽ có thứ tự
# Cú pháp:
# enumerate(iterable[, start])
# (start + 0, seq[0]), (start + 1, seq[1]), (start + 2, seq[2]), ...
student_list = ['Long', 'Trung', 'Giàu', 'Thành']
gen = enumerate(student_list)
print(gen)
print(list(gen))
# hoặc
student_list = ['Long', 'Trung', 'Giàu', 'Thành']
for i,student in enumerate(student_list):
    print(i,'=>',student)

student_list = ['Long', 'Trung', 'Giàu', 'Thành']
for student in enumerate(student_list,3):
    print('=>',student)

for i,student in enumerate(student_list,9):
    print(i,'=>',student)









