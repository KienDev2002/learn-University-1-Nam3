
#if , elif , else




a = 1
b = 3
if a-1<0:
    print('a-1 nho hon 0')
    if(b-1<0):
        print('b-1 nho hon khong')
    else:
        print('b-1 lon hơn bằng 0')
elif a-1>0:
    print('a-1 lon hơn bằng 0')
    if(b-1<0):
        print('b-1 nho hon khong')
    else:
        print('b-1 lon hơn bằng 0')
else:
    print('a-1  bằng 0')
    if(b-1<0):
        print('b-1 nho hon khong')
    else:
        print('b-1 lon hơn bằng 0')

# Một số điều lưu ý về việc định dạng code block trong Python:


# Câu lệnh mở block kết thúc bằng dấu hai chấm (:), sau khi sử dụng câu lệnh có dấu hai chấm (:) buộc phải xuống dòng và lùi lề vào trong và có tối thiểu một câu lệnh để không bỏ trống block.
# Những dòng code cùng lề thì là cùng một block.
# Một block có thể có nhiều block khác.
# Khi căn lề block không sử dụng cả tab lẫn space.
# Nên sử dụng 4 space để căn lề một block

# hoặc
print('viết ngắn gon:' , end=' ')
a = 1
if a>0:print('a lon hon 0')
elif a<0:print('a nho hon 0')
else :print('a = 0')

































