a = input('Nhap so thu nhat:')
b = input('Nhap so thu hai:')

try:
    c  = int(a)
    d = int(b)
    e = c + d
    print('Tong 2 so bat ki:',e)
except:
    print('Định dạng không hợp lệ')