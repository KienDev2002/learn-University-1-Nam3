
USE BT2
--1. Tạo login Login1, tạo User1 cho Login1
EXEC sp_addlogin Login1,123
EXEC sp_adduser Login1,User1


--2. Phân quyền Select trên bảng DSSinhVien cho User1
GRANT SELECT ON dbo.DSSinhVien TO User1

--3. Đăng nhập để kiểm tra


--4. Tạo login Login2, tạo User2 cho Login2
EXEC sp_addlogin Login2,123
EXEC sp_adduser Login2, User2


-- 5. Phân quyền Update trên bảng DSSinhVien cho User2, người này có thể cho phép người khác sử dụng quyền này
GRANT UPDATE ON dbo.DSSinhVien TO User2 WITH GRANT OPTION 

