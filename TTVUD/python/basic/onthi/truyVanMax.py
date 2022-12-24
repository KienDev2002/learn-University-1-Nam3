#cay IT truy van max
class node:
    def __init__(self,a, b):
        self.L, self.R = a,b #left là a, right là b
        self.elem = -1e9 #các ptu đều là âm vô cùng
        if a==b:  #chỉ có node gốc
            self.left, self.right= None , None
        else:
            # có node thì con trái là các node từ a đến (a+b)/2
            self.left = node(a, (a+b)//2)
            # có node thì con phải là các node từ (a+b)/2 đến b
            self.right = node((a+b)//2+1,b)

def update(H, i, x):
    # nếu ptu < x đc nhập vào lớn hơn gốc thì gốc là ptu x
    if H.elem < x: H.elem = x
    # nếu như con trái có ptu
    if H.left != None:
        # nếu i mà nhỏ hơn H.left.R thì đệ quy lại gốc lúc này sang con bên trái ngược lại sang phải
        update(H.left if i<=H.left.R else H.right, i, x)

def get(H, u, v):
    # trong cùng 1 node thì trả về ptu đó
    if u==H.L and v == H.R:
        print(H.elem)
        return H.elem
    if u<=H.left.R and H.right.L <=v:
        return max(get(H.left, u, H.left.R), get(H.right, H.right.L, v))
    return get(H.left if v<=H.left.R else H.right, u, v)

if __name__ == '__main__':
    # nhập n phần tuuwf và m số lần suy vấn
    n, m = map(int, input().split())

    # khởi tạo node và gán - vô cùng chp ptu
    H = node(1, n)

    # nhập n phần từ và rót ptu vào đúng vị trí thu i cua no
    for i, x in enumerate(input().split(), 1):
        update(H, i, int(x))

    for i in range(m):
        # nhập khoảng u đến v
        u,v=map(int, input().split())
        # tìm ptu lớn nhất u đến v,
        print(get(H, u, v))
