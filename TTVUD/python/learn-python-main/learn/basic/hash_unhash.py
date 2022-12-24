
# ham id trả về giá trị địa chỉ
a = id([1,2,3]) 
print(a)


n= 69
print(n)
print(n+1)
print(n.__add__(1))  #giống ở trên
print(n.__radd__(1))  #right add giống ở trên
print(n.__neg__())  #trừ đi 1


#+= giống với = a + b
# s_1 = 'kien'
# s_2 = 'cuong'
# s_1 = s_1 + 'python'
# s_2+= 'python'
# print(id(s_1))
# print(id(s_2))



# s_2 không bị thay đổi địa chỉ
s_1 = [1,2]
s_2 = [3,4]
print(id(s_1))
print(id(s_2))
s_1 = s_1 + [0]
s_2 += [0]
print(id(s_1))
print(id(s_2))
print(s_2)


# => __add__ giống với += : hash object ko có phương thức này , và khác với = a + b
# => những thằng ko thể thay đổi giá trị là hash object: như là tuple và chuỗi , key và unhash object là list,set,dict
# => unhash object khi muốn cộng thêm python không biết cộng vào chỗ nào nên địa chỉ của nó không bao giờ là khác nhau: giống nhau
# => hash object có thể thay đổi đc nội dung vì thế  khi muốn cộng thêm python luôn sinh ra bộ nhớ để thêm vào nên địa chỉ của nó sẽ khác nhau


# có thể thay đổi tuple bằng cách
# list có hàm append nhưng tuple thì ko
s_1 = [1,2]
print(id(s_1))
s_1 = s_1.append(3)
print(s_1)
print(id(s_1))
# nên ta dùng cách này để thay đổi tuple bằng toán tử
s_1 = (1,2)
print(id(s_1))
s_1+=(3,4)
print(s_1)
print(id(s_1))




# Tại sao có List lại còn sinh ra Tuple? Hoặc là sử dụng Tuple thôi, cần gì tới List?
# Đáng lẽ, Kteam sẽ nói vấn đề này ở bài trước, nhưng vì muốn bản hiểu hơn về các hash object với unhash object nên đã để tới bài này.

# Bạn dễ dàng nhận thấy, việc ta thay đổi giá trị của Tuple, không nhất thiết là phải trực tiếp như List.

# Các bạn cũng thấy, nó không khác nhau là mấy. Ta cũng có thể tạo ra các hàm thay đổi nội dung của Tuple bằng cách slicing. Đã thế List lại còn nặng về việc chiếm nhiều dung lương hơn Tuple, truy xuất chậm hơn Tuple. Việc gì khiến nó còn được trọng dụng?

# Vì khi bạn thay đổi Tuple như cách trên, Python phải đi vòng vòng trong bộ nhớ của bạn tìm xem chỗ nào trống, phù hợp để chứa cái Tuple của bạn không, 
# trong khi với List thì không. Do đó, bạn phải biết được dữ liệu của bạn là dạng dữ liệu như thế nào, có cần phải thay đổi không. Dựa vào đó, để chọn ra một kiểu dữ liệu phù hợp cho mình, tối ưu hóa dung lượng sử dụng, thời gian truy xuất.


# => Tóm lại: muốn thay đổi thì dùng kiểu dữ liệu list, còn ko thì dùng tuple nó sẽ đỡ tốn bộ nhớ và dung lượng hơn






