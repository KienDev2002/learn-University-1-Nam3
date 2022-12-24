

# khác với list

# được giới hạn bởi cặp ngoặc ()
# các phần ử tuple đc phân cách nhau bởi dấu , (giống list)
# chứa đc mọi giá trị
# dung lượng chiếm nhỏ hơn list
# tốc đọ truy xuất nhanh hơn list: 
# dung lượng chiếm trong bộ nhớ nhỏ hơn list: đỡ tốn nhiều ram
# bảo vệ dữ liệu sẽ không bị thay đổi: ko thể thay đổi, chỉ khởi tạo 1 ptu tuple mới
# có thẻ dùng key của từ điển: list ko thể vì nó là 1 hash object




a = [1,2,4,'kien']
print(a)

print('tuple:')
tup = (1,4,3,6,4,2,8,'kien',(2,4,2))
print(tup)


tup = (1,)  # Th này là kiêu int, muốn thành tuple thì thêm dâu sphaary sau
print(tup)




#tuple tạo ra 1 danh sách for thì phải qua thằng constructor tuple
tup = (i for i in range(10))
a = tuple(i for i in range(10) if i % 2==0)
print(a)




#toan tở tuple giống với chuỗi, list với chuỗi gần giống
tup = (1,5,9)
a = tup+(2,4,6)
tup +=(4,5,6) # cộng thêm
tup *=2 # toán tử nhân 2 lân lên
b = 2 in tup # xác định 2 có trong tuple hay không
print(a)
print(tup)
print('Có 2 trong ko:')
print(b)





#giống list
a = (1,5,9)
a = tup[1]  #truyxuaats index bawst buộc dùng ngoặc tròn
print(a)




#độ dài ptu
print('ddo dài:')
b = len(tup)
c = tup[len(tup)-1] 
c = tup[-1] 
c = tup[::-1] # ddaor nguoc tuple
c = tup[:-1] # lấy ptu bao nhiêu đến bao nhiêu
print(b)
print('ptu cuoi day la:')
print(c)





#ma trận
tup = ((1,5,9),(1,5,9),(1,5,9))
print(tup)





#thay đổi nội dung: ko thể
# tup[0] = 'kien'                     #lỗi
# print(tup)

#thay đổi đc thì dùng
tup = ([1,5,9,4])
tup[2] = 'kien'
print(tup)





#methods tuple
tup = (1,2,4,7)
a = tup.count(1)  # soos laanf xuất hiện cua 1
a = tup.index(2) # lấy ra vị trí xuất hiện đầu tiên của số 2
print(a)




















