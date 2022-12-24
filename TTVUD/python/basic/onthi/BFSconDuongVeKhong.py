import math
import queue
A = []
def bfs(n):
    global A
    Q = queue.Queue()
    d = [0] * (n+5) # tạo mảng d có n + 5 số 0
    Q.put(n) #put n vào
    d[n] = 1 #ptu thứ n đã xét thì đánh dấu là 1, sau đó tách n
    while(Q.qsize()):
        u = Q.get() #lấy ptu đầu ra
        for i in range(1, int(math.sqrt(u) + 1)): # vì từ 1 đến căn n thì u mới có thể chia hết được
            if u % i == 0:
                v = (i-1) * (u//i + 1)
                if d[v]==0: #nếu vị trí v chưa xét thì put v vào queue
                    Q.put(v)
                    d[v] = 1 # put xong thì đánh dấu là đã xét
    for i in range (n+1):
        if d[i]==1:
            A.append(i)

if __name__ == '__main__':
    n = int(input())
    bfs(n)
    print(*A,sep="\t")