
exec sp_addlogin A,123
exec sp_addlogin B,123
exec sp_addlogin C,123

use QLBH
exec sp_adduser A,userA
exec sp_adduser B,userB
exec sp_adduser C,userC

grant select, update on NhaCungCap to userA


exec sp_droplogin B
exec sp_droplogin C
exec sp_dropuser userB
exec sp_dropuser userC