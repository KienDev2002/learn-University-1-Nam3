
# Chuỗi cũng có thể  nằm trong ''' vvv ''', """  vvv   """

# TH phải dùng nháy  kép
a = "I'am student"   
print(type(a))


#TH vừa có dấu nháy đơn và có cả dấu nháy kép. thì dùng \" , \' vì là nó sẽ in ra kí tự " và '
b = " \"I\'am \"kien\" "
print(b)



#chuỗi nhiều dòng.  Dùng dấu '''  kí tự  ''' hoặc """ kí tự  """

c = '''I am a student
I am a teacher
I am a doctor
'''

print(c)
# Khi nhấn enter là nó xuất hiện \n: là kí tự xuống dòng.


# comment nhiều dòng
'''
đây là comment nhiều dòng
'''


'''escape sequence là các kí hiệu 
 \a: phát ra 1 tiếng bíp 
 \b: Đưa con trỏ trỏ trở lại 1 khoảng trắng
 \n: Đưa con trỏ xuống dòng tiếp theo
 \t: in ra 1 tab
 \": in ra kí tự "
 \\: in ra tự (\)
 \': in ra kí tự '
'''

print('\a')

print(b)