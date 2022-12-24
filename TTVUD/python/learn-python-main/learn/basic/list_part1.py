

# biến ko thể lưu 1 lúc nhiều thông tin, chỉ lưu đc 1

#list: danh sách 1 chiều, giới hạn bởi ngoặc vuông [], casc ptu cách nhau dấu phẩy
# có khả năng mọi giá trị đối tượng python và gồm chính nó
from typing import Iterable


a = [[1,2,3],1,2,3,6,5,'ateam']
print(a)



# cách khởi tại list
a = [i for i in range(30)]  # biến i chạy từ vị trí 0 trong pham vi là 30 ptu từ 0->29
print(a)


# n chạy trong khoảng từ 2 đến 4 (2,3, <4)
a = [[n,n*1,n*2] for n in range(2,4)] # khởi tạo n đầu tiên là 2 list trong la [2,2,4] sau đó tăng n so sánh với  4 nho hơn thì n= [3,3,6] n tăng  sau đó so sánh với 4 <4 mới làm tiếp
print(a)




# a = list(iterable: dạng cấu trúc tập hợp nhiều phần tử)
#constructor list: bóc tách các kí tự
a = list([1,2,3])
a = list('kien')  
print('\n\n\n')
print(a)


#toán tử list: 1 chuỗi ko thể cộng với list
# a = 'kien'  * lỗi : vì 1 chuỗi ko thể cộng với list
a = [1,2]
# a*=['one','two'] # lỗi: vì ko thể nhân 2 list
a *= 2  # có thể nhân chuỗi lên nhoieeuf lần
print(a)


#kiếm tra xem 1 có nằm trong a hay ko
b = 1 in a #true
b = 'kteam' in a #false
print(b)


# index có thể -: -1 là cuối
a = [1,2,'a','b','c',[3,4]]
# b = a[5]
# b = a[5][0] # chỉ số index, mảng đầu là list cha index = 5, mảng 2 là index thứ 0 trong index 5 là list con
# b = a[1:3] # lấy từ 1 đến 3: 1,2
# b = a[:3] #lấy tù đầu đến 3: 1,2,3
# b = a[::-1] #lấy toàn bộ sau đó đảo ngược
b = a[3::2]  # bước nhảy tử vị trí index la 3 mỗi bưỡ nhảy là 2
print(b)



#thay đổi list
a = [1,2,'a','b','c',[3,4]]
a[1] = 'kien'  #thay đổi vị trí list index 1
b = a[1]
print(b)
print(a)


#ma trận: mảng 2 chiều
a = [[1,2,3],[4,5,6],[7,8,9]] 
print(a[0][0])  # : index có thể là âm: lấy ptu co 1 list cha cos index 0 va list con có index là 0
print(a[1][1])
print(a[2][0])





#ko thể gán list này cho list kia: khi thay đổi cả 2 list đều bị đổi, vì nó cùng 1 giá trí cùng trỏ đến 1 vùng nhớ
a = [1,2,3]
b = a
print(b)
print(a)
b[0] = 'kien'  # thay đổi cả list a
print(b)
print(a)


#để giải quyết vấn đề này ta thêm dùng constructor list
a = [1,2,3]
b = list(a) # matran thif vẫn bị thay đổi cả 2, để giải quyết ta xét vd dưới
print(b)
print(a)
b[0] = 'kien'  # không thay đổi cả list a
print(b)
print(a)




# nếu sử dụng constructor list và có thay đổi 1 giá trị của phần tử trong list con thì nó sẽ thay đổi theo, nếu thay đổi 1 list cha ko bị thay đổi cả
#ma trận chỉ thay đổi cả 1 list con chứ ko thể thay đổi 1 ptu trong list con
# VD: copy 1 matran
print('gan 2 ma tran\n')
a = [[1,2,3],[4,5,6],[7,8,9]] 
b = list(a)
print(a)
print(b)

b[0] = [9,8,7]
print(a) 
print(b)
























