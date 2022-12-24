


# lập lịch cho cô y tá.

'''
    n,k1,k2 = 0,0,0
def TRY(x,k): #giả sử đã có phần đầu x và cuối xâu x có k số 1 liên nhau
    if len(x)==n:
        if k==0 or k>=k1:
            print(x)
    else:
        if x=='' or k>= k1 :
            TRY(x+'0',0)
        if k<k2:
            TRY(x+'1',k+1)

if __name__ == '__main__':
    n,k1,k2 = map(int,input().split())
    TRY('',0)


'''



#lai ghép

'''
a = ''
b = ''
def TRY(x,i):
    if i==len(a):
        print(x)
    else:
        u,v = a[i],b[i]
        if u > v:
             u,v = v,u
        TRY(x+u,i+1)
        if u!=v:
            TRY(x+v,i+1)

if __name__ == '__main__':
    a = input()
    b = input()
    TRY('',0)


'''

# lại là lai ghép
a = ''
b = ''
def TRY(x,i):
    if i==len(a): print(x[2:])
    else:
        u,v = a[i],b[i]
        if u > v:
            u, v = v, u
        if x[-2] == 'A' or x[-1]=='A' or u == 'A': TRY(x+u,i+1)
        if u != v:
            if x[-2] == 'A' or x[-1] == 'A' or v == 'A': TRY(x + v, i + 1)

if __name__ == '__main__':
    a = 'AA' + input()
    b ='AA'+ input()
    TRY('AA',2)