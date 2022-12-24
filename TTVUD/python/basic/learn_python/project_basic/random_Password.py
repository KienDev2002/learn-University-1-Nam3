




import string
import  random

LETTERS = string.ascii_letters
NUMBERS = string.digits
PUNCTUANTION = string.punctuation
#print(LETTERS,NUMBERS,PUNCTUANTION,sep="\n")

def password_generator(length):
    printable = f'{LETTERS}{NUMBERS},{PUNCTUANTION}'
    #convert sang List(mảng) để random ra
    printable = list(printable)

    #chộn ngẫu nhiên
    random.shuffle(printable)

    #chọn ra chuoi co do dai bang 8
    random_pass = random.choices(printable,k = length)

    #convert từ list sang string để hiển thị
    random_pass = ''.join(random_pass)
    return random_pass


def main():
    n = int(input())
    password = password_generator(n)
    print(password)

if __name__ == '__main__':
    main()









