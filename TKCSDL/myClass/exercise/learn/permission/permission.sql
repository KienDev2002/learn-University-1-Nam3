
--tạo  login để đăng nhập vào 1 login khác.
exec sp_addlogin N02,123
create login NO2 with password = '123'
--xóa login
exec sp_droplogin N02




--add user là N02user cho NO2 có thể xem đc db của QLBH, nhưng lúc này sẽ ko hiển thị các bảng cho nên chúng ta cần chia phân quyền cho nó
exec sp_adduser N02, N02user 
create user N02user for login N02
--xóa user
exec sp_dropuser N02user
drop user N02user






--tạo nhóm quyền
exec sp_addrole Tên_role
create role ten_user

--xóa nhóm quyền
exec sp_droprole Tên_role
drop role Tên_role





--Người dùng & nhóm quyền
exec sp_addrolemember tên_role , tên_user

--Xóa nhóm quyền
exec sp_droprolemember tên_role, tên_user





--grant: chia phân quyền: chia quyền select update cho N02user trên bảng nhân viên ở các cột   trong login N02.
grant select , update on NHANVIEN to N02user
--grant: chia phân quyền: chia quyền select update cho N02user trên bảng nhân viên ở các cột Ho,Ten,NgaySinh  trong login N02.
grant select , update on NHANVIEN(Ho,Ten,NgaySinh) to N02user



--revoke: xóa các quyền: xóa quyền select update cho N02user trên bảng nhân viên ở các cột Ho,Ten,NgaySinh trong login N02.
revoke select , update on NHANVIEN(Ho,Ten,NgaySinh) to N02user



--Lệnh DENY dùng để ngăn quyền của người dùng
--Câu lệnh ngăn quyền update trên bảng NHANVIEN của người dùng N02user
DENY update ON NHANVIEN to N02user
