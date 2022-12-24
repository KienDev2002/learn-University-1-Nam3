

'''

#ko thể thay đổi đc value string
a = "ngokien"
a[0] = 'mg'
print(a)   # error vì string ko thể thay đổi đc value


#   join()
my_list = ['how','are','you']
s = '-'.join(my_list)  #nối các how are you cách nhau là dấu '-'
print(s)




#strip(): xóa đi kí tự 2 dsaauf
print("   kien      ".strip())  #xóa khoảng tramwsg đầu
print("On tkien      s".strip('O'))  #xóa chữ O đầu đi




#replace(chuoi can thay, chuoi thay)
print('help me'.replace('me','you'))


#startswith(""): kiểm tra chuỗi đầu có bắt đầu là kí tự gì đó ko
print("end kien".startswith("end"))  #true
print("end kien".startswith("e"))  #true
print("end kien".startswith("ee"))  #false



#index: trả về vị trí index nếu có, ko tìm đc báo lỗi
my_string = 'ngokien'
print(my_string.index('e'))
print(my_string.index('q')) #substring not found




#find: tương tự như index nhưng nó nếu ko tìm đc thì ra -1
print(my_string.find('e'))  # 5
print(my_string.find('q'))  # -1






#title(): in hoa chữ đầu
#capitalize(): chữ đầu hoa
#count(''): count 1 kí tự
#upper(): sang chuỗi in hoa





#string format: % , format(), f-string
name = 'kien'
age = 12
my_string = "welcom to %s co %d tuoi" %(name,age)
print(my_string)



#string format:  format()
age = 20
height = 170.345
my_str = "I am {}, {:.2f}".format(age,height)
print(my_str)




# #string format:   f-string: koieeur nội suy
name = "kien"
pi = 3.14456456
height = 170.123123
my_str = f"Pi is {pi:.2f} end my name {name}, heght: {height:.2f}"
print(my_str)
'''





