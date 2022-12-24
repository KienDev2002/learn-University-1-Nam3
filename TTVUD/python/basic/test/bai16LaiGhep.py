


a = ''
b = ''

def TRY(x,n,i):
    if len(x)==n:
        print(x)
    else:
        u,v = a[i],b[i]
        if u>v:
            u,v = v,u
        TRY(x+u,n,i+1)
        if u!=v:
            TRY(x+v,n,i+1)


if __name__ == '__main__':
    a = input()
    b = input()
    TRY('',len(a),0)