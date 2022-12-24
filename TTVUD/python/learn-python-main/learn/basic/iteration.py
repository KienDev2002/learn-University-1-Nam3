


#lý thuyết ở kteam
iter1= [x for x in range(3)]  # là iterable object: Iterable object là một object có phương thức __iter__ trả về một iterator, hoặc là một object có phương thức __getitem__ cho phép bạn lấy bất cứ phần tử nào của nó bằng indexing ví dụ như Chuỗi, List, Tuple 
iter2 = (x for x in range(3)) #là iterator object: nên ko thể truy xuất trực tiếp mà phải triết xuất từng phần từ với hàm next()
print(iter1)
print(next(iter2))
print(next(iter2))
print(next(iter2))

# Một số hàm hỗ trợ cho iterable object trong Python

# Một điều lưu ý:  Các hàm này buộc phải lấy các giá trị của iterable để xử lí, do đó nếu bạn đưa vào một iterator. Thì bạn sẽ không sử dụng iterator đó được nữa.
# Hàm tính tổng – sum
# Cú pháp:
# sum(iterable, start=0)

# Công dụng: Trả về tổng các giá trị của iterable và iterable này chỉ chứa các giá trị là số. Còn start chính là giá trị ban đầu. Có nghĩa là sẽ cộng từ start lên. Mặc định là 0
print('\ncộng sum:')
iter2 = (x for x in range(3)) #là iterator object: nên ko thể truy xuất trực tiếp mà phải triết xuất từng phần từ với hàm next()
print(sum(iter2,2))
print(sum(iter2,-2))
print(sum(iter2,3))




# File object cũng là một iterator. Bạn cũng có thể sử dụng cách này để đọc file.
print('file object:')
lst = [6, 3, 7, 'kteam', 3.9, [0, 2, 3]]
iter_list = iter(lst) # iter_list là một iterator tạo từ list
# iter_list[0] # đương nhiên, iterator không hỗ trợ indexing
print(next(iter_list))
print(next(iter_list))
print(next(iter_list))




# Hàm tìm giá trị lớn nhất – max
# Cú pháp:
# max(iterable, *[, default=obj, key=func])
# Công dụng: Nhận vào một iterable.Tìm giá trị lớn nhất bằng key (mặc định là sử dụng operator >). Default là giá trị muốn nhận về trong trường hợp không lấy được bất kì giá trị nào trong iterable.

# Dấu * chính là kí hiệu yêu cầu keyword-only argument. Bạn sẽ hiểu thêm khi Kteam giới thiệu parameter trong function.
print('\nMax, min = ')
iter2 = (x for x in range(3))
# print(max(iter2))
print(min(iter2))
print(max(9,4,3,2))
print(min(9,4,3,2))
print(max([],default='Kteam'))  # Nếu ko có thì show ra default Kteam
print(min([],default='Kteam'))  # Nếu ko có thì show ra default Kteam


# Hàm sắp xếp – sorted
# Cú pháp:
# sorted(iterable, /, *, key=None, reverse=False)

# Công dụng: Giống với phương thức sort của List object.
print('\nSort:')
a = ([1,5,8,9,3])
print(sorted(a))
print('\nSort ngược: ')
print(sorted(a,reverse = True))




















