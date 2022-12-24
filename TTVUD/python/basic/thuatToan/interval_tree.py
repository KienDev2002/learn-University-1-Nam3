# Cây IT (Interval Tree)

# A = [-999999999] * 400005
# def update(k, L, R, i, x):
#     if L == R: A[k] = x
#     else:
#         # if A[k] < x: A[k] = x
#         if i <= (L+R)/2: update(2*k+1, L, (L+R)/2, i, x)
#         else: update(2*k+2, (L+R)/2 + 1, R, i, x)
#         A[k] = max(A[2*k+1], A[2*k+2])
#
# def get(k, L, R, u, v):
#     if u == L and v == R:
#         return A[k]
#     if v <= (L+R)/2: return get(2*k+1, L, (L+R)/2, u, v)
#     if u > (L+R)/2: return get(2*k+2, (L+R)/2 + 1, R, u, v)
#     return max(get(2*k + 1, L, (L+R)/2, u, (L+R)/2), get(2*k + 2, (L+R)/2 + 1, R, (L+R)/2 + 1, v))
#
# if __name__ == '__main__':
#     n, m = map(int, input().split())
#     temp = list(map(int, input().split()))
#     for i, x in enumerate(temp):
#         update(0, 1, n, i, x)
#     while m != 0:
#         u, v = map(int, input().split())
#         print(get(0, 1, n, u, v))
#         m -= 1

class node:
    def __init__(self, a, b):
        self.elem = -1e9  #các ptu đều là âm vô cùng
        self.L, self.R = a, b #left là a, right là b
        if a == b: #chỉ có node gốc
            self.left, self.right = None, None
        else: # có node thì con trái là các node từ a đến (a+b)/2
            self.left = node(a, (a+b)//2)

            # có node thì con phải là các node từ (a+b)/2 đến b
            self.right = node((a+b)//2 + 1, b)


def update(H, i, x):
    #nếu ptu < x đc nhập vào lớn hơn gốc thì gốc là ptu x
    if H.elem < x: H.elem = x
    #nếu như con trái có ptu
    if H.left != None:
        #nếu i mà nhỏ hơn H.left.R thì đệ quy lại gốc lúc này sang con bên trái ngược lại sang phải
        update(H.left if i <= H.left.R else H.right, i, x)


def get(H, u, v):
    #trong cùng 1 node thì trả về ptu đó
    if H.L == u and H.R == v: return H.elem

    if u <= H.left.R and v >= H.right.L:
        return max(get(H.left, u, H.left.R), get(H.right, H.right.L, v))
    return get(H.left if v <= H.left.R else H.right, u, v)

if __name__ == '__main__':
    #nhập n phần tuuwf và m số lần suy vấn
    n, m = map(int, input().split())

    #node goosc H và có các node từ 1 đến n
    H = node(1, n)

    #nhập n phần từ và rót ptu vào đúng vị trí thu i cua no
    for i, x in enumerate(input().split(), 1):
        update(H, i, int(x))

        #truy vấn , lần
    for i in range(10):
        #nhập khoảng u đến v
        u, v = map(int, input().split())
        #tìm ptu lớn nhất u đến v,
        print(get(H, u, v))
