




matrix = [[1,2,3],
          [4,5,6],
          [7,8,9]]
print(matrix[2][1])

#c1
for row in range(len(matrix)):
    for col in range(len(matrix)):
        print(matrix[row][col])


#c2: chuyen sang list
list_converted =  [ matrix[row][col] for row in range(len(matrix)) for col in range (len(matrix))]
print(list_converted)



#lay ra gia tri cua tung cot
print([ x for x in zip(*matrix)])







