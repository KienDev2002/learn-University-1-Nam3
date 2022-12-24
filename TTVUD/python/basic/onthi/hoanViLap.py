
from collections import Counter

def TRY(x, n, L, D):
    print("X= %s"  %x)
    if len(x) == n:
        print(x)
    else:
        for k in L:
            print("for %s" %k)
            if D[k] > 0:
                D[k] -= 1
                print("D[%s] - 1 = %d" % (k, D[k]))

                TRY(x + k, n, L, D)
                D[k] += 1
                print("D[%s] + 1 = %d" % (k, D[k]))

if __name__ == '__main__':
    x = input()
    D = Counter(x) #tạo dic có key là các chữ cái và value là số chữ cái trong x
    print(D)
    L = sorted(D.keys()) # sx các chữ cái tăng dần và ko lặp lại
    print(L)
    TRY('', len(x),L, D)