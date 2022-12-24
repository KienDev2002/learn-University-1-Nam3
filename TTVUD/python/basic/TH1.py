#Trao giải chung kết marathon
'''

import collections
if __name__ == '__main__':
    sv=collections.namedtuple("SV","ten,diem")
    D,K=[],[] #khoa điện và khoa khác.
    n=int(input())
    for i in range(n):
        ten,diem,khoa=input().rsplit(' ',2)
        #thêm khoa điện và điện điện tử vào D , còn khoa khác là thêm vào K
        D.append(sv(ten,int(diem))) if khoa == "DDT" else K.append(sv(ten,int(diem)))
    #sx số điểm trong DDT
    D.sort(key = lambda x: x.diem, reverse=True)

    #show ra 3 thnwgf cao nhất của D
    print("Giai nhat :%s"%D[0].ten)
    print("Giai nhi :%s"%D[1].ten)
    print("Giai ba :%s"%D[2].ten)

    #và show ra phần từ lớn nhất.
    k=max(K,key= lambda x:x.diem)
    print("Giai giao luu :%s"%k.ten)
'''


#Sắp xếp danh sách sinh viên
import datetime
'''
import sys
import datetime
import  collections

if __name__ == '__main__':
    sv = collections.namedtuple("sv","Ten,ngaysinh,gioitinh,id")
    D = []
    for i, ip in enumerate(sys.stdin):
        t,n,g = ip.rsplit(None,2)
        d,m,y = map(int,n.split("/"))
        n = datetime.datetime(y,m,d)
        D.append(sv(t,n,g,i))

        #sx theo ngay sinh, nếu ngày sinh giống nhau thì sx theo id.
    D.sort(key=lambda x:(x.ngaysinh,x.id))
    for x in D:
        print("%s %d/%d/%d %s"%(x.Ten,x.ngaysinh.day,x.ngaysinh.month,x.ngaysinh.year,x.gioitinh))


'''

#ngay tiep theo: timedelta theo ngày, theo tuần,...
'''
    import  datetime
    d,m,y = map(int,input().split('/'))
    x= datetime.datetime(y,m,d)
    x+=datetime.timedelta(days=1)
    print("%d/%d/%d"%(x.day,x.month,x.year))
'''



#Tính điểm thi lập trình

'''
import  collections
if __name__ == '__main__':
    n = int(input())

    #lấy dòng đầu nhập cho các trường sv và cộng với TD
    sv = collections.namedtuple("sv",input()+" TD")
    DS = []
    for i in range(n):
        x = input()+" 0" #dòng ddaatf tiên

        y = sv._make(x.split()) #gán các giá trị dòng đầu cho từng thằng sv


        #tính điểm và gán cho TD trong sv
        y = y._replace(TD=int(y.A) + 2 * int(y.B) + 3 * int(y.C) + 4 * int(y.D) + 5 * int(y.E))
        DS.append(y)

    #sx theo ten
    DS.sort(key=lambda x: x.TEN)
    for s in DS:
        print(s.TEN, s.TD)



    # sv = collections.namedtuple("sv","A,B,C,D")
    # d = [4,7,2,8]
    #từ list sang kieu sv
    # x = sv._make(d)
    #
    # #thay thế dữ liệu trong trường
    # x= x._replace(A=6)
    # print(x.A)

'''




#Bieu Thuc Hau To BaLan


'''

import queue

ut = {"*":2,"/":2,"+":1,"-":1,"(":0}
def balan(ip):
    global ut
    out  = ""
    S = queue.LifoQueue()
    for c in ip:
        if '0'<= c <='9':
            out+=c
        elif c=='(': S.put(c)
        elif c==')':
            #lấy hết cho đến khi gặp dấu (
            while S.queue[-1] != '(':
                out+=S.get()
            #lấy dấu ( ra
            S.get()
        else:
            #stack còn ptu thì xét độ ut
            while S.qsize() and ut[S.queue[-1]]>= ut[c]: out+=S.get()

            #stack rỗng thì put vào
            S.put(c)

    #hết ptu thì còn bao nhiêu trong stack lấy ra hết
    while S.qsize():
        out+=S.get()

    return  out



def tinh(out):
    S = queue.LifoQueue()
    for c in out:
        if '0'<= c <='9':
            S.put(int(c))
        else:
            a,b = S.get(),S.get()
            if c=="+": S.put(b+a)
            elif c=="-": S.put(b-a)
            elif c=="*": S.put(b*a)
            else: S.put(b//a)

    return S.get()

if __name__ == '__main__':
    str = input()
    print(balan(str))
    print(tinh(balan(str)))

'''



#Chào đón tân sinh viên K59


import math
import  queue

if __name__ == '__main__':
    n = int(input())
    a = list(map(int,input().split()))
    S = queue.LifoQueue()
    S.put((-1,1e9))
    L = [0] * n
    for i,x in enumerate(a):
        # lấy gias trị của đỉnh stack.
        while S.queue[-1][1] <= x:
            S.get()
        # lấy vị tría của đỉnh stack gans cho L[i].
        L[i] = S.queue[-1][0]
        #ở vị trí i có giá trị la 0
        S.put((i,x))
    R = [0] * n
    S = queue.LifoQueue()
    S.put((-1,1e9))
    for i in range(n-1,-1,-1):
        while S.queue[-1][1] <= a[i]: S.get()
        R[i] = S.queue[-1][0]
        S.put((i,a[i]))
    for i in range(n):
        if L[i]==-1 or R[i]==-1:print(L[i] + R[i] + 1 , end=" ")

        else:print(L[i] if i - L[i] <= R[i]-i else R[i] , end=" ")











