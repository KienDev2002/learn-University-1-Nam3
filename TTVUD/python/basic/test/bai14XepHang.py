

import queue

def sol():
    n = int(input())
    S = queue.LifoQueue()
    res=0

    for x in map(int,input().split()):
        while S.qsize() and S.queue[-1][0] < x:
            res+=S.queue[-1][1]
            S.get()
        if S.qsize() and  S.queue[-1][0]==x:
            res+=S.queue[-1][1] + (S.qsize()>1)
            S.queue[-1][1]+=1
        else:
            res+=S.qsize()>0
            S.put([x,1])

    print(res)




if __name__ == '__main__':
    sol()