



def unique(str):

    char_dic= {}
    for char in str:
        if char in char_dic:
            return False
        else:
            char_dic[char] = True
    return  True

if __name__ == '__main__':
    str = input()
    print(unique(str))