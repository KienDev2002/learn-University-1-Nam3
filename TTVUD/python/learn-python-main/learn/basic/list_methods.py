


a = [1,2,3,4,5,1,7,9]
# số lần xuất hiện của 1 số
c = a.count(1)
print(c)


#vị trí xuất hiện của số 4
c = a.index(4)
print(c)


#tao ra 1 bản sao, gioosnf như list constructor sẽ tạo ra 1 thằng nữa ko trỏ đến cùng 1 vùng nhớ
c = a.copy()
c[0] = 'kien'
print(c)
print(a)


#xóa
c = a.clear()
print(c)
print(a)


# cập nhật theem
print('\n\nCập nhật thêm:')
a = [1,2,3]
# a.append(4)
a.append([4,5])  # tạo thêm 1 list con nằm trong list cha
print(a)



print('\n\nCập nhật thêm:')
a = [1,2,3]
a.extend([4,5,[7,8]])  #không tạo ra list con, mà nó chỉ bổ sung thêm thôi
# a.extend([4,5])  #không tạo ra list con, mà nó chỉ bổ sung thêm thôi
print(a)




# Theem vị trí x bằng y ở trong list, nếu lớn hơn độ dài list thì nó đưa về cuối list
print('\n\nCập nhật thêm:')
a = [1,2,3]
a.insert(2,5)  #thêm 5 vào 2
# a.insert(-1,5)  #thêm 5 vào vị trí 1 từ dưới lên
print(a)



# xóa ở vị trí thứ x: là đối phương thức
print('\n\nXóa :')
a = [1,2,3]
a.pop(0) # nếu tham số ko truyền vào thì mặc định sẽ là ptu cuối cùng
print(a)


# xóa ptu x
print('\n\nXóa :')
a = [1,1,2,3]
a.remove(1)
# a.remove(1)
print(a)


# đảo ngược list
print('\nđảo :')
a = [1,1,2,3]
a.reverse()
print(a)




# sắp xếp nhỏ đến lớn
a = [1,1,2,3,'kien']  # phải cùng kiểu ko là lỗi
a = [1,1,2,3]  # phải cùng kiểu ko là lỗi
a.sort()
print(a)
 #sắp xếp lớn về bé
a.sort(reverse = True) 
print(a)
