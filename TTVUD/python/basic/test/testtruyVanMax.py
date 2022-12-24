



class node:
    def __init__(self,a,b):
        self.elem = -1e9
        self.L, self.R = a,b
        if a==b:
            self.Left, self.Right = None,None
        else:
            self.Left = node(a,(a+b)//2)
            self.Right = node((a+b)//2+1,b)


def update(H,i,x):#H(1->6) i = 3, x = 2
    if H.elem <x: H.elem = x
    if H.Left!=None:
        update( H.Left if i <= H.Left.R else H.Right,i,x)

def get(H,u,v): # H(4->5) u = 4, v = 5 -> 8, max(7,8)-> 8
    if H.L ==u and H.R ==v: return H.elem
    if u<=H.Left.R and v>=H.Right.L:
        return max(get(H.Left,u,H.Left.R), get(H.Right,H.Right.L,v))
    return get(H.Left if v<= H.Left.R else H.Right,u,v)

if __name__ == '__main__':
    n,m = map(int,input().split())
    H = node(1,n)
    for i,x in enumerate(map(int,input().split()),1):
        update(H,i,x)
    for i in range(m):
        u,v = map(int,input().split())
        print(get(H,u,v))