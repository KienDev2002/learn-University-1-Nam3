
'''

def codexplore(a,b,c):
    print(a,b,c)

def main():
    #pass #để nếu ko cần điền gì
    codexplore(a = "hello" , c = "coder" , b = 2) #call function thi no se gan cho ban nó dc đặt


if __name__ == '__main__':
    main()





#args:cac doi so truyen vao con lai
    def variable_length(a,b,*args):
        print(a,b)
        for arg in args:
            print(arg) #cac doi so truyen vao con lai

    def main():
        variable_length('a','b','hello world',1,2,3)

    if __name__ == '__main__':
        main()
'''



#kwargs: là 1 dict nen la co the duyet for, là các dic truyen vao con lai
def variable_length(a,b,*args, **kwargs):
    print(a,b)
    for arg in args:
        print(arg) #cac doi so truyen vao con lai

    for key, value in kwargs.items():
        print(key ,value)

def main():

    variable_length('a','b','hello world',age = 'NG', size = 'up size')

if __name__ == '__main__':
    main()































