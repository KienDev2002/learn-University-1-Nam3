

a = 'kiên năm nay %s %s tuổi' %('19' , '20')
print(a)

a = 'kiên năm nay %r %s tuổi'
print(a %('19' , '20'))



a = 'kiên năm nay %d %.2f tuổi'
b=a %(2 , 2.345)
print(b)


a = 'kiên năm nay %d %.2f tuổi'
b=a %(2 , 2.345)
print(b)


a = 'kteam'
c = 'KKK'
b = f'{a} có Kiên {c}'
print(b)


a = 'kteam'
b = 'KKK'
c = 'có Kiên'
print(f'a = {a}\nb = {b}\nc = {c}')
print('a = {}\nb = {}\nc = {}'.format('kien' , 'ngo' , 'pro'))
print('a = {2}\nb = {0}\nc = {1}'.format('kien' , 'ngo' , 'pro'))
print('a = {a}\nb = {b}\nc = {c}'.format(a = '1' , b = '2' , c = '3'))





# Căn lề: {:(c)<n,>n,^n}: c là kí tự muốn thay thế chỗ trống, > căn lề phải , < căn lề trái , ^ căn giữa
print('\na = {:&>10}'.format('kien'))


row_1 = '+ {:->6} + {:-^15} + {:->10} +'.format('','','')
row_2 = '| {:<6} | {:^15} | {:>10} |'.format('ID','Ho va ten','Noi sinh')
row_3 = '| {:<6} | {:^15} | {:>10} |'.format('123','ngo kien','nam dinh')
row_4 = '| {:<6} | {:^15} | {:>10} |'.format('234','Ngo cuong','thai binh')
row_5 = '+ {:-<6} + {:-^15} + {:->10} +'.format('','','')
print(row_1)
print(row_2)
print(row_3)
print(row_4)
print(row_5)











