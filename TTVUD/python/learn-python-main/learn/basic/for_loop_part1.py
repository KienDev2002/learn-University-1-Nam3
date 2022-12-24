
# Hạn chế của vòng lặp while
length = 3
iter_ = (x for x in range(length))  #0,1,2
c = 0
while c < length:
    print(next(iter_), end=' ')
    c += 1
print('\n')
# Nếu bạn không biết trước được số phần tử mà iterator đó có thì cũng không sao. Python vẫn cho phép bạn làm được điều đó bằng try-block (Kteam sẽ giới thiệu ở một bài khác)
iter_ = (x for x in range(3)) # giả sử ta không biết có 3 phần tử
while 1: # 1 là một expression True
    try: #cố gắng làm chuyện này
        print(next(iter_))
    except StopIteration:  #break khi thấy stop vì là dùng hàm next ở dòng trên
        break

# => 0,1,2


# for variable_1, variable_2, .. variable_n in  n ptu sequence:
#     # for-block

inter_ = (x for x in range(3))
for value in inter_: # với mỗi ptu trong inter_ thực hiện được thay thế bởi value
    print('->' , value)  # coi value là cái next


#dic: key vaf value
dic = {'name':'Kteam' , 'kter':69 , 'kien':'kien ngo'}
print(dic.items())
list_i = list(dic.items()) # biến dic về 1 list để duyệt index
print(list_i[0])
for key,value in dic.items():
    if (key=='kter'):
        break
    else:
        print(key,'=>',value)  


#key
d = {1: 'one', 2: 'two', 3: 'three'}
for i in d:
    print(i)


# Cũng sẽ tương tự như while-else, vòng lặp hoạt động bình thường. Khi vòng lặp kết thúc, khối else-block sẽ được thực hiện. Và đương nhiên nếu trong quá trình thực hiện for-block mà xuất hiện câu lệnh break thì vòng lặp sẽ kết thúc mà bỏ qua else-block.
for k in (1, 2, 3):
    print(k)  
    if k%2==0: #bếu k chẵn break luôn và ko thực hiện else
        break
else:
    print('Done!') #khi for heest thif nó chạy else, giống while else


















