
res = 0
class node:
    def __init__(self,a,b):
        self.elem = 0
        self.end = b
        if a==b:
            self.Left,self.Right = None,None
        else:
            self.Left = node(a, (a + b) // 2)
            self.Right = node((a + b) // 2 + 1, b)

def update(H,x): #H(1->5) x= 2
    global res
    H.elem+=1
    if H.Left!=None:
        if x <= H.Left.end:
            res += H.Right.elem
            update(H.Left, x)
        else:
            update(H.Right, x)


if __name__ == '__main__':
    n = int(input())
    H = node(1,n)
    for x in list(map(int,input().split())):
        update(H,x)
    print(res)


'''
    5
    4 5 1 3 2
'''