
a = ''
b = ''
def TRY(x,i):
    print("x: %s, i: %d" %(x,i))
    if i==len(a):
        print(x)
    else:
        u,v = a[i],b[i]
        print("u = %s" %u)
        print("v = %s" %v)

        if u > v:
            u,v = v,u
            print("u = %s" % u)
            print("v = %s" % v)
        TRY(x+u,i+1)

        print("u !=v = %s, i = %d" % (u,i))
        print("v !=v = %s, i = %d" % (v,i))
        if u!=v:
            print("banktracking")
            TRY(x+v,i+1)

if __name__ == '__main__':
    a = input()
    b = input()
    TRY('',0)