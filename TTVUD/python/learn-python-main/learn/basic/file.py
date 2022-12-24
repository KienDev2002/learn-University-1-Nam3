
# Mở File trong Python
# open(file, mode='r', buffering=-1, encoding=None, errors=None, newline=None, closefd=True, opener=None)
# Công dụng: Ở mức độ cơ bản, chúng ta sẽ chỉ quan tâm đến 2 parameter: file và mode.

# help(open)
file_obj = open('kien.txt')
# print(file_obj)



# Phương thức read
# <File>.read(size=-1)

# Công dụng: Nếu size bị bỏ trống hoặc là một số âm. Nó sẽ đọc hết nội dung của file đồng thời đưa con trỏ file tới cuối file. Nếu không nó sẽ đọc tới n kí tự (với n = size) hoặc cho tới khi nội dung của file đã đọc xong.
# Sau khi đọc được nội dung, nó sẽ trả về dưới một dạng chuỗi.
# Nếu không đọc được gì, phương thức sẽ trả về một chuỗi có độ dài bằng 0
data = file_obj.read()
data = file_obj.read(3)  # đọc từng kí tự 1
file_obj.close()
print(data)




# <File>.readline(size=-1)
# Công dụng: Với parameter size thì hoàn toàn tương tự như phương thức read.

# Khác biệt ở chỗ, phương thức readline chỉ đọc một dòng có nghĩa là đọc tới khi nào gặp newline hoặc hết file thì ngừng.
# Con trỏ file cũng sẽ đi từ dòng này qua dòng khác.
# Kết quả đọc được trả về dưới dạng một chuỗi.
# Nếu không đọc được gì, phương thức sẽ trả về một chuỗi có độ dài bằng
file_obj = open('kien.txt')

data1 = file_obj.readline()
data2 = file_obj.readline() 
print(data1)
print(data2)



# Phương thức readlines
# <File>.readlines(hint=-1)

# Ở mức độ cơ bản, ta không phải quan tâm đến parameter hint.

# Công dụng: Phương thức này sẽ đọc toàn bộ file, sau đó cho chúng vào một list. Với các phần tử trong list là mỗi dòng của file.

# Con trỏ file sẽ được đưa  tới cuối file. Khi đó, nếu bạn tiếp tục dùng readlines. Bạn sẽ nhận được một list rỗng.
file_obj = open('kien.txt')

data1 = file_obj.readlines()
data2 = file_obj.readlines() 
print(data1)
print(data2)




# Đọc file bằng constructor nhận iterable
file_obj = open('kien.txt')
data1 = list(file_obj)
print(data1) #in ra giống trên list của readlines


file_obj = open('kien.txt')
data1 = tuple(file_obj)
print(data1) # trả về ds tuple


# # Ghi File trong Python
# Phương thức write
# Cú pháp:
# <File>.write(text)

# Công dụng: Phương thức này sẽ trả về số kí tự mà chúng ta ghi vào.
file_obj = open('kien.txt',mode = 'a+')
data1 = file_obj.write('\nkien ngo cntt')  #show ra số kí tự vào 
print(data1) 



# Kiểm soát con trỏ file
# Phương thức seek
# <File>.seek(offset, whence=0)
# Công dụng: Phương thức này giúp ta di chuyển con trỏ từ vị trí đầu file qua offset kí tự. Và parameter offset phải là một số tự nhiên.

# Nhờ phương thức này, ta có thể ghi nội dung từ bất cứ đâu trong file.
# Và từ đó ta có thể đọc lại file sau khi ta đưa con trỏ file xuống cuối file.
file_obj = open('kien.txt',mode = 'r')
data = file_obj.read()
file_obj.seek(0)  # đưa con trỏ về vị tri k
data2 = file_obj.read()
print(data)
print(data2)



# Câu lệnh with
# Cấu trúc cơ bản của câu lệnh with là

# with expression [as variable]:
#     with-block    
# Nhớ rằng with-block nằm thụt vào so với dòng with expression (theo chuẩn PEP8 là 4 space và là dùng space không dùng tab)
# Câu lệnh này liên quan đến phương thức __enter__ và __exit__ của đối tượng. Do đó, ở đây Kteam sẽ nói cơ bản khi sử dụng file.

with open('kien.txt') as fobj:
    data = fobj.read()  #đọc xong đóng file luôn
print(data)
fobj.read() # không thể đọc file, vì file đã đóng

