import queue
if __name__ == '__main__':
    S= queue.LifoQueue()
    n=int(input())
    res=0 #đếm xem có bao nhiêu cặp nhìn thấy nhau
    for x in map(int,input().split()):
        while S.qsize() and S.queue[-1][0]<x:
            res+=S.queue[-1][1]
            print("size < %d" % S.qsize())
            S.get()
            print("res < : %d" % res)
        if S.qsize() and S.queue[-1][0]==x:
            res+=S.queue[-1][1] + (S.qsize()>1)
            S.queue[-1][1]+=1
            print("size =  %d" % (S.qsize() > 1))
            print("res = : %d" % res)
        else:
            res+=S.qsize()>0
            S.put([x,1])
            print(res)
    print(res)