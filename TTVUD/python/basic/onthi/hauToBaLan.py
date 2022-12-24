
import queue

ut = {"*":2,"/":2,"+":1,"-":1,"(":0}
def balan(ip):
    global ut
    out  = ""
    S = queue.LifoQueue()
    for c in ip:

        if '0'<= c <='9':
            out+=c

        elif c=='(': S.put(c)

        elif c==')':
            #lấy hết cho đến khi gặp dấu (
            while S.queue[-1] != '(':
                out+=S.get()
            #lấy dấu ( ra
            S.get()

        else:
            #stack còn ptu thì xét độ ut
            while S.qsize() and ut[S.queue[-1]]>= ut[c]: out+=S.get()

            #stack rỗng thì put vào
            S.put(c)

    #hết ptu thì còn bao nhiêu trong stack lấy ra hết
    while S.qsize():
        out+=S.get()

    return  out


def tinh(out):
    S = queue.LifoQueue()
    for c in out:
        if '0'<= c <='9':
            S.put(int(c))   #chú ý convert sang int vì nó đddang là chuỗi
        else:
            a,b = S.get(),S.get()
            if c=="+": S.put(b+a)
            elif c=="-": S.put(b-a)
            elif c=="*": S.put(b*a)
            else: S.put(b//a)

    return S.get()


if __name__ == '__main__':
    str = input()
    print(balan(str))
    print(tinh(balan(str)))