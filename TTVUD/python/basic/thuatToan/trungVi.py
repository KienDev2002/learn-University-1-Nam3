



# ptu trung vị: thêm vào là sx
# import queue
# L = queue.PriorityQueue()
# R = queue.PriorityQueue()
# n, *a = list(map(int,input("").split()))
# for i,x in enumerate(a):
#     if i%2:
#         R.put(x) #sx tăng dần
#     else:
#         L.put(-x) #sx tăng dần
#
#     if i > 0 and -L.queue[0] > R.queue[0]:
#         u,v = L.get(),R.get()
#         L.put(-v)
#         R.put(-u)
#     print(-L.queue[0],end=" ")
