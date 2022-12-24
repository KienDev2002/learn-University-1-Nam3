
#python ko có giới hạn kiểu như các c, c++, nó phân biệt HOA VÀ THƯỜNG



# số nguyên
a = 4  # gán cho a là 4 với 4 là kiểu số nguyên (intergers)
print(a)
print(type(a))  #lấy kiểu dữ liệu của a




# Số thực: lấy số sau dấu phẩy sấp xỉ 15 số thập phân.
b = 1.234455666543322772234
print(b)
print(type(b))




#kiểu cao hơn 15 số thập phân, là kiểu, lấy toàn 
# decimal
#phải import decimal 
from decimal import*
# from numbers import Complex  # phải gọi kiểu import thư viện decimal

# lấy tối đa 30 chữ số phần nguyên và phần thập phân decimal
getcontext().prec = 3 # để sau lệnh này decimal chia nó sẽ lấy 3 chữ số cả trước dấu phẩy
print(Decimal(10)/Decimal(3))  # để như này nó hiểu là decimal và in ra 30 chữ số

f = 10/3  # để như này nó sẽ hiểu là kiểu float
print(Decimal(10)/Decimal(3))
print(f)

# TH: 1 cái ko là decimal: thì nó hiểu cả biểu thưc là decimal
d = Decimal(10)/3   
print(type(d))





# kiểu phân số, tự rút gọn
from fractions import*  # thư viện fraction
frac1  = Fraction(6,9)
frac2  = Fraction(5,10)
print(frac1)
print(type(frac1))  # kiểu số fraction
frac3 = frac1 + frac2
print(frac3)





#số phức: gồm thực và ảo , j la phần ảo trong toán học , j bình = -1
c =  complex(2,5)
print(c.real)   # lấy phần thực
print(c.imag)  # lấy phần ảo




# các phép toán
# +,-,*,/: lấy phần thực , //: lấy phần nguyên , x **y : lũy thữa x mũ y
c = 10//3
print(c)
d = 10/3
print(d)
e = 2**3  # 2 mũ 3
print(e)

