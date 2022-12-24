
a = 4
while a > 0:
    print(a)
    a -=1
#break: kết thúc vòng lặp ngay khi thực hiện lệnh này
s = 'Ngô Kiên Lớp CNTT2'
i = 0
length = len(s)
while (i<length):
    print(i , 'có giá trị la: ' , s[i],end='\n')
    i+=1
    if (i==5):
        break


#continue: Bỏ qua lần lặp đó
k_number = 1
while k_number < 10:
     if k_number % 2 == 0: # nếu k_number là số chẵn
         k_number += 1  # thì tăng một đơn vị cho k_number và tiếp tục vòng lặp
         continue
     print(k_number, 'is odd number')
     k_number += 1



# while expression:

#     # while-block

# else:

#     # else-block

# Cấu trúc này gần tương tự như while bình thường. Thêm một điều, khi vòng vòng lặp while kết thúc thì khối lệnh else-block sẽ được thực hiện.

k = 0
while k < 3:
    print('value of k is', k)
    k += 1
else:
    print('k is not less than 3 anymore')


























