
from collections import Counter

def TRY(x,n,L,D):
    if len(x)==n:
        print(x)
    else:
        for c in L:
            if D[c] > 0:
                D[c]-=1
                TRY(x+c,n,L,D)
                D[c]+=1

if __name__ == '__main__':
    n = input()
    D = Counter(n)
    L = sorted(D.keys())
    TRY('',len(n),L,D)