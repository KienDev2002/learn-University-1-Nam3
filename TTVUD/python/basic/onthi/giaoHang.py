



import queue
if __name__ == '__main__':
    A = [[] for i in range (100005)] #A là 1 list các mảng rỗng. gồm chỉ số thời gian (t) trong 1 mảng thời gian là các giá trị (v).
    n = int(input())
    for i in range (n):
        t,v = map(int,input().split())
        A[t].append(v)
    res = 0
    Q = queue.PriorityQueue() #mặc định PriorityQueue là sx tăng dần
    for i in range(100000,0,-1):# thu hoạch nho từ cuối lên
        for x in A[i]: #3 duyệt các value trong 1 thời gian t
            Q.put(-x) #sx giảm dần
        if(Q.qsize()):
            res += Q.get()  #lấy lớn nhất ra rồi cộng vào.
    print(-res)

    '''
6
3 5
3 7
1 3
2 4
2 2
4 1
'''