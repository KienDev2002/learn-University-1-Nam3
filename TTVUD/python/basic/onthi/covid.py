import queue

if __name__ == '__main__':
    n, m = map(int, input().split())  # doc vao so dan, so cap
    F = [0] * 1000005  # So nguoi bi benh tung F0, F1, F2,...
    danhDau_F = [-1] * (n + 5)  # Xac dinh xem nó thuộc F nào, -1 la khong mac covid
    tiep_xuc = [[] for i in range(n + 5)]
    for i in range(m):  # doc vao danh sach cac cap tiep xuc
        u, v = map(int, input().split())
        tiep_xuc[u].append(v)
        tiep_xuc[v].append(u)
    F[0] = int(input())  # so f0
    Q = queue.Queue()  # nhung nguoi bi tinh la F0, F1, F2,...
    for i in list(map(int, input().split())):  # doc vao danh sach f0
        Q.put(i)
        danhDau_F[i] = 0 # ban đầu nhập cho số đó là F0
    while Q.qsize():
        u = Q.get() # lấy lần lượt giá trị F0, F1, F2 ra đã put lần lượt
        for v in tiep_xuc[u]: # duyệt các thằng đã tiếp xung với u
            if danhDau_F[v] == -1:  # hỏi xem nó có bị F nào ko, nếu -1 là 0 bị F thì gán cho nó bị Fn
                danhDau_F[v] = danhDau_F[u] + 1
                Q.put(v)
                F[danhDau_F[v]] += 1
    i = 0
    while F[i]:
        print("F%d: %d" % (i, F[i]))
        i += 1


'''
9 4
3 6
4 5
1 7
7 9
2
3 9 
'''