


# thuật toán chạy nhị phân
# from math import  *;
# # hình tròn tìm điểm trong đường tròn và gần M nhất
# def kc (x,y,z,t): return pow(x-z,2) + pow(y-t,2);
#
#
# if __name__ == '__main__': #hàm main
#     xO,yO,r,xM,yM = map(float,input().split());
#     if kc(xO,yO,xM,yM) <= r*r: print(xM,yM);
#     else:
#         xP,yP = xO,yO;
#         while abs(xP-xM) > 1e-5 or abs(yP-yM)>1e-5:
#             xQ = (xP + xM) /2;
#             yQ = (yP + yM) /2;
#             if kc(xO,yO,xQ,yQ) > r*r:
#                 xM,yM = xQ,yQ;
#             else:
#                 xP,yP = xQ,yQ;
#         print(xM,yM);

#print(float(1e-5))