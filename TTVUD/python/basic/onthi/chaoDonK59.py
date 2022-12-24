#https://lmsutceduvn.sharepoint.com/sites/ThchnhThuttonvngdngCNTT2-K61/_layouts/15/stream.aspx?id=%2Fsites%2FThchnhThuttonvngdngCNTT2%2DK61%2FShared%20Documents%2FGeneral%2FRecordings%2FCu%E1%BB%99c%20h%E1%BB%8Dp%20trong%20%5FChung%5F%2D20221019%5F072514%2DB%E1%BA%A3n%20ghi%20cu%E1%BB%99c%20h%E1%BB%8Dp%2Emp4
import  queue

def sol():
    n = int(input())  # n sinh vien
    a = list(map(int, input().split()))  # chieu cao cua n sinh vien
    S = queue.LifoQueue()

    S.put((-1, 1e9))  # put (-1, 1000000000.0) vào S
    L = [0] * n  # mảng n số 0, đi từ trái sang, sau đó sau đó đi từ bang sang rồi so sánh 2 bên

    for i, x in enumerate(a):
        # lấy gias trị của đỉnh stack.
        print("S.queue %d" % S.queue[-1][1])
        while S.queue[-1][1] <= x:  # nếu số thêm vao lớn hơn thì sẽ lấy số cũ ra để cho số mới đó vào để nó lấy số mà lớn hơn mà gần nhất.
            S.get()

        # lấy ra vị trí thằng lớn và gaanf nhất
        L[i] = S.queue[-1][0]
        print("L[%d]: %d" % (i, L[i]))
        # ở vị trí i có giá trị la 0
        S.put((i, x))

    R = [0] * n  # đi từ phải sang rồi so sánh 2 bên
    S = queue.LifoQueue()
    S.put((-1, 1e9))

    for i in range(n - 1, -1, -1):
        print("S.queue %d" % S.queue[-1][1])
        while S.queue[-1][1] <= a[i]:
            S.get()
        R[i] = S.queue[-1][0]
        print("R[%d]: %d" % (i, R[i]))
        S.put((i, a[i]))

    print(L)
    print(R)

    for i in range(n):
        if L[i] == -1 or R[i] == -1:
            print(L[i] + R[i] + 1, end=" ")
        else:
            print(L[i] if i - L[i] <= R[i] - i else R[i], end=" ")
        # khoảng cach L, R ben nào nhỏ hơn thì lấy

if __name__ == '__main__':
    sol()
    '''
4
1 4 2 7
    '''