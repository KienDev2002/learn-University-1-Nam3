

#map:Lại là Dãy con liên tục khác biệt
if __name__ == '__main__':
    M = {}
    n = input().split()
    L,res = 0,-1
    for i,x in enumerate(map(int,input().split())):
        #nếu ptu lặp lại thì vào
        if x in M.keys() and M[x] >= L:
            L = M[x]+1
            print("L:" ,L,M[x])

        #nếu ptu khác thì nó tăng lên
        if res < i-L+1:
            res = i-L+1
            print("res:", res)

        M[x]=i

    print(res)