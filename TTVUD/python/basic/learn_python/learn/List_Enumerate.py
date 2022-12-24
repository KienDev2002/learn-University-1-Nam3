
'''

#list giống mảng
    list1 = ["banana",'apple','orange']
    list2 = ["banana",None,3]
    list3 = list() # tajo mang
    print(list1,list2,list3,sep="\n")


    #len(list_name): độ dài list




    list2 = ["banana",2,3,'3']
    print(list2.index(3))
    print(list2.index('3'))
    for item in list2:
        print(item)




#enumerate
    my_list = ["banana",2,3,'3']
    for index,item in enumerate(my_list, start=1): # start=1: cho bd = 1
        print(f'#{index}: {item}')




#slicing: cắt: [start : end : step]
    my_list = ["banana",2,3,'3']
    print(my_list[1:])
    print(my_list[:3])
    print(my_list[-1]) #3
    print(my_list[::2])



# add to List
    my_list = ["banana",2,3,'3']
    print(my_list*2)
    my_list.append(100) #add 1 gia tri
    print(my_list)

    my_list.extend([100,'coder']) #add nhieu gia tri
    print(my_list)


    my_list.insert(3,'kien')  #insert kien vao vi tri 3
    print(my_list)




#remove from list
    my_list = ["banana",2,3,'3']
    print(my_list.pop()) #lay ptu cuoi va xoa ptu cuoi
    print(my_list)

    print(my_list.pop(2)) #lay ptu thu 2 va xoa ptu thu 2
    print(my_list)

    my_list.remove(2) #xoa gia tri so 2, neu nhieu so 2 thi xoa gia tri 2 dau tien
    print(my_list)


    my_list = ["banana",2,3,'3']
    del my_list[0] #xoa o vi tri 0
    print(my_list)




#sort
    my_list = [1,2,4,54,2,7,1]
    my_list.sort()
    print(my_list)
    my_list.sort(reverse=True) #sort giam dan
    print(my_list)

#reverse
    my_list.reverse() #đảo chỗ ngược lại
    print(my_list)


#sorted
    my_list = [1,2,4,54,2,7,1]
    print(sorted(my_list)) #sx tăng dần ko ảnh hưởng đến my_list hiện tại
    print(my_list)

    my_list = [1, 2, 4, 54, 2, 7, 1]
    print(sorted(my_list))  # sx tăng dần ko ảnh hưởng đến my_list hiện tại
    print(my_list)

    my_list = ['hi','hello','you','CodeExplore']
    sorted_by_Second = sorted(my_list,key=lambda el: el[1])  # sx tăng dần theo key el[1] la ptu thu 2
    print(sorted_by_Second)


    my_dic = [{'name': 'coder' , 'age': 15},{'name': 'kien' , 'age': 20},{'name': 'Zoo' , 'age': 23}]
    my_dic_sorted_by_name = sorted(my_dic,key=lambda el: el['name']) #sx theo tên
    print(my_dic_sorted_by_name)


#reversed
    my_list = [1,2,4,54,2,7,1]
    print(list(reversed(my_list))) #đảo chỗ ko ảnh hưởng đến my_list hiện tại
    print(my_list)




'''

