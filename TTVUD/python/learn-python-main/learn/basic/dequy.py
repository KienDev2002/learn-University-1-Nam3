
#c1
def call_sum (lst):
    if not lst: # nếu lst ko có ptu
        return 0
    else:
        return lst[0] + call_sum(lst[1:])
print(call_sum([1,2,3,4]))


# c2
def call_sum(lst):
    return 0 if not lst else lst[0]+call_sum(lst[1:]) # neesu lst ko có ptu có độ dài là 0 thì trả về 0
print(call_sum([1,2,3,4]))



#c3
# Giả sử một list có n phần tử thì với đệ quy như trên cần phải có n + 1 lần return, ta có thể giảm bớt xuống còn n lần return bằng cách:
def call_sum(lst):
    return lst[0] if len(lst)==1 else lst[0] + call_sum(lst[1:])
print(call_sum([1,2,3,4]))
# Lưu ý: cách này không sử dụng được trong trường hợp container rỗng

# c4:
# Hoặc ta có thể sử dụng packing argument:

def call_sum (lst):
    idx0, *r = lst #idx0 luwu tung ptu vao cho den cuoi xong return ra, r se bij maat daanf
    print(idx0,'=>',r)
    return idx0 if not r else idx0 + call_sum(r) #coong chuoi nen la: ''+a = a + b = ab +c = abc cho den khi het ptu trong r thi return abc
print(call_sum([1,2,3,4]))

# Lưu ý: cách này cũng không sử dụng được khi container là rỗng. Tuy nhiên điểm lợi của nó cũng như cách vừa nãy là ta có thể cộng không chỉ số mà là chuỗi, hoặc list
print(call_sum(['a','b','c']))
print(call_sum([[1,2], [3,4] , [5,6]]))



# Đệ quy cũng có thể chuyển hướng. Hãy xem ví dụ sau. Một hàm gọi một hàm khác, sau đó lại gọi lại hàm đã gọi nó.
def call_sum(lst):
    if not lst: return 0
    else: return call_cal_sum(lst)
def call_cal_sum(lst):
    return lst[0] + call_sum(lst[1:])
print(call_sum([1,2,3,4]))















