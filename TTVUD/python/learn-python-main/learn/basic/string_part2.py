
#chuỗi trần: thêm r vào trước: để sửa các kí tự escape sequence
print(r'haizz, \neu một ngày nào đó')



# toán tử "+" nối chuỗi
stra = "kien.com"
strb = "trường đhgtvt"
strc = stra + "\n" +  strb
print(strc)




#toán tử "*" nhân với số k lần lặp
stra = "kien.com" + "\n"
strb = "trường đhgtvt"
strc = stra * 4
print(strc)




# toàn tử in trả về true hoặc false
stra = "kien.com" + "\n"
strb = "t"
strc = strb in stra
print(strc)


#toán từ ":": để lấy chuỗi gì
stra = "kien.com"
# lấy chuỗi từ vị trí thứ 1 đến 5, 1:None: từ 1 đến cuối dãy, hoặc None:5 từ đầu dãy đến 5
strb = stra[1:None]
strc = stra[None:5]
# TH này lấy cả chuỗi
strd = stra[:]
print(strb)
print(strc)
print(strd)


#  mảng: chỉ số có thể là âm: đi từ phải qua trái
stra = "kien.com"
strc = stra[-3]
print(strc)
# hàm "len(..)" lấy ra độ dài chuỗi
a =  len(stra)
print(a)




#toán tư ::
stra = "kien.com"
# từ đầu : đến đâu : bước nhảy ( khác 0)
strb = stra[None:5:2]
print(strb)
# đi ngược từ cuối đến vị trí 5 bước nhảy là -1
strc = stra[None:None:-1]
print(strc)



#ép kiểu: 
# chuỗi thành số
strA = float("69") + 5
strA = int("69") + 5
# số thành chuỗi
strB = str("kien") + "5"
print(strA)
print(strB)


# python ko hỗ trợ thay đổi giá trị của chuỗi
strA = "kien.com"
strA = strA[None:1] + "0" + strA[2:None]
print(strA)
# hamf hash: show ra mã hash: mỗi lần sẽ hiện ra 1 hằng khác, ko thể thay đổi
print(hash(strA))























