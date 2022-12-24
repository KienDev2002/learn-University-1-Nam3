



# import queue
# class item:
#     def __init__(self,x):
#         self.val = x
#
#     def __lt__(self, other): #lesser than
#         return self.val < other.val  if self.val%3 == other.val%3 else self.val%3 < other.val%3
#
#
# if __name__ == '__main__':
#     Q = queue.PriorityQueue()
#     for x in [45,567,235,547,678,745,234,6,8]:
#         Q.put(item(x))
#     while Q.qsize():
#         print(Q.get().val, end=" ")