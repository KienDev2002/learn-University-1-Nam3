
import queue

if __name__ == '__main__':
    Q =  queue.PriorityQueue()
    n,k = map(int,(input()).split())
    for i,x in enumerate(map(int,input().split()),1):
        Q.put((-x,i))
        if i >= k:
            while i - Q.queue[0][1] >=k:
                Q.get()
            print(-Q.queue[0][0], end="\t")


