
#lý thuyeesy tronmg kteam
# Đây là lệnh chỉ sử dụng được ở trong hàm (nếu sử dụng ở ngoài hàm sẽ có nhắc lỗi)

def cal_rec_per(width, height):
    per = (width + height) * 2
    return per

rec_1_width = 5
rec_1_height = 3
# khởi tạo một biến để hứng kết quả
rec_1_per = cal_rec_per(rec_1_width, rec_1_height)

print(rec_1_per)

# trường hợp này là khi bạn không cần tái sử dụng nó ở lần sau
print(cal_rec_per(7, 4))







#găp lệnh return thì kết thúc hàm luôn ko in ở dưới
def _return_ter_func():
    print('chúng ta sử dụng return để ngắt hàm')
    # dòng dưới đây tương tự như bạn viết return None
    return
    print('Hàm print này dĩ nhiên không được gọi')

none = _return_ter_func()
print(type(none))









# Dùng return để trả về nhiều giá trị một lúc
# Với Python, việc bạn có thể return nhiều giá trị một lúc bản chất nó không nằm ở câu lệnh Python, mà là do Python thiết kế đặc biệt để có thể unpack các object trả về. Bạn hãy xem ví dụ về khai báo sau đây
def cal_rec_area_per(width, height):
    perimeter = (width + height) * 2
    area = width * height
    return perimeter, area # trả ra 2 giá trị cùng 1 lúc

rec_width = 3
rec_height = 9
rec_per, rec_area = cal_rec_area_per(rec_width, rec_height)  #nhận 2 giá trị nạp vào 2 biến

print(rec_per, rec_area)










