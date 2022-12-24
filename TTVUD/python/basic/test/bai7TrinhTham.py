


import queue

if __name__ == '__main__':
    n,k = map(int,input().split())
    PQ = queue.PriorityQueue()

    for i,x in enumerate(map(int,input().split()),1):
        PQ.put((-x,i))
        if i>=k:
            while i-PQ.queue[0][1]>=k:
                PQ.get()
            print(-PQ.queue[0][0], end="\t")