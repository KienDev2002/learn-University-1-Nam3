
import queue
import math

d = [0] * 10000  # mean [0,0,..,0] 10000 elem 0
def dfs(n,stack):
    print("n: %d" %n)
    for i in range(1,int(math.sqrt(n))+1,1):
        if n%i==0:
            v = (i-1)*(n//i+1)
            print("v: %d" %v)
            if d[v] == 0:
                stack.put(v)
                d[v] = 1
                dfs(v,stack)

if __name__ == '__main__':
    n = int(input())
    stack = queue.LifoQueue()
    stack.put(n)
    d[n] = 1
    dfs(n,stack)
    for i in range(n+1):
        if d[i]:
            print(i, end = " ")