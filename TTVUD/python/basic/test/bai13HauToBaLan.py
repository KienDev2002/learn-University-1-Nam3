import  queue

ut = {"*":2,"/":2,"+":1,"-":1 , "(":0}

def biendoi(str):
    out = ""
    S = queue.LifoQueue()
    for c in str:
        if "0" <=c <="9":
            out+=c
        elif c == "(":
            S.put(c)
        elif c==")":
            while S.qsize() and S.queue[-1]!="(":
                out+=S.get()
            S.get()
        else:
            while S.qsize() and ut[S.queue[-1]] >= ut[c]:
                out+=S.get()
            S.put(c)
    while S.qsize():
        out+=S.get()
    return out

def tinh(str):
    S = queue.LifoQueue()
    for c in str:
        if "0" <=c <="9":
            S.put(int(c))
        else:
            a,b = S.get(),S.get()
            if c=="+": S.put(b+a)
            elif c=="-": S.put(b-a)
            elif c=="*": S.put(b*a)
            else: S.put(b//a)
    return S.get()

if __name__ == '__main__':
    str = input()
    print(biendoi(str))
    print(tinh(biendoi(str)))
