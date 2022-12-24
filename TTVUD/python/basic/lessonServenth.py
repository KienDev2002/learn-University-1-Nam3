

# hàng đợi ưu tiên.
# nối thanh kim loại.
#import queue
'''
    Q = queue.PriorityQueue()
    n = input()
    for x in input().split(): Q.put(int(x)) #nhập từng thanh
    res = 0
    while (Q.qsize() > 1):
        u = Q.get() + Q.get()
        res += u
        Q.put(u)
    print(res)

'''





# A = [[]] * 5
# Giao hàng
'''
    A = [[] for i in range (100005)] #A là 1 list các mảng rỗng. gồm chỉ số thời gian (t) trong 1 mảng thời gian là các giá trị (v).
    n = int(input())
    for i in range (n):
        t,v = map(int,input().split())
        A[t].append(v)
    res = 0
    Q = queue.PriorityQueue()
    for i in range(100000,0,-1):# thu hoạch nho từ cuối lên
        for x in A[i]: 3 duyệt các value trong 1 thời gian t 
            Q.put(-x) #sx giảm dần
        if(Q.qsize()):
            res += Q.get()  #lấy lớn nhất ra rồi cộng vào.
    print(-res)
'''


#cài đặt Heap
class PQ:
    def __init__(self, ok = True):
        self.a = []
        self.ut = ok

    def empty(self):
        return len(self.a) == 0

    def qsize(self):
        return len(self.a)

    def top(self):
        return self.a[0]

    def put(self,x):
        self.a.append(x)
        k = len(self.a) - 1
        while k>0 and (self.a[(k-1)//2] < self.a[k]) == self.ut: #nếu cha mà nhỏ hơn con là đúng thì thực hiện swap
            self.a[(k-1)//2],self.a[k] = self.a[k] , self.a[(k-1)//2]
            k = (k-1)//2 # và duyệt tiếp k là cha cho tới khi k < 0 và cha lớn hơn con thì dừng


    def get(self): #swim ptu
        x = self.a[0] #lấy thằng gốc ra
        self.a[0] = self.a[-1] #đổi gốc với lá cuối cùng
        self.a.pop() #xong xóa thằng cuối, lúc nayf lá là nhỏ nhất lên gốc
        if len(self.a) > 0: #
            self.Heapy(0) #swim từ gốc xuống, vì lúc này gốc là thằng vừa đổi nó vi phạm heap nên duyệt từ gốc.
        return x #lấy ra ptu lớn nhất khi là max heap, nhỏ nhất khi là min heap.

    def Heapy(self,k): #swim ptu
        p = 2*k + 1; # lấy con trái của k
        if p>=len(self.a): return # nếu lớn hơn độ dài
        if p+1 < len(self.a) and (self.a[p] < self.a[p+1])==self.ut: #nếu con phải < độ dài a và con trái nhỏ hơn con phải là đúng thì p+1 thì lúc lúc p là con phải
            p+=1
        if (self.a[k] < self.a[p])==self.ut: # nếu ptu cha < con bên phải là đúng thì swap con phải là cha và cha là con
            self.a[k], self.a[p] =   self.a[p] ,self.a[k]
            self.Heapy(p) #đệ quy tiếp lúc này cha là p đã xuống dưới khi swap xong và duyệt tiếp chính nó và con cho đến hết.

if __name__ == '__main__':
    # Q = PQ(True) ưu tiên lớn. max heap
    # Q = PQ(False) # ưu tiên bé. min heap

    Q = PQ(True) # ưu tiên lon. max heap là ptu đầu tiên
    for x in ["chipheo","thino","laohac","onggiao","bakien","lycuong","baba","cauvang"]:
        Q.put(x)
    while Q.qsize():
        print(Q.get(), end=" ")



















