create database QLChatLieu
use QLChatLieu

create table BangChatLieu(
	MaChatLieu nvarchar(20) not null primary key,
	TenChatLieu nvarchar(20) not null
)

insert into BangChatLieu(MaChatLieu,TenChatLieu) values(N'MCL01',N'Sắt')
insert into BangChatLieu(MaChatLieu,TenChatLieu) values(N'MCL02',N'Nhôm')
insert into BangChatLieu(MaChatLieu,TenChatLieu) values(N'MCL03',N'Nhựa')
insert into BangChatLieu(MaChatLieu,TenChatLieu) values(N'MCL04',N'Cao su')
insert into BangChatLieu(MaChatLieu,TenChatLieu) values(N'MCL05',N'Thép')
insert into BangChatLieu(MaChatLieu,TenChatLieu) values(N'MCL06',N'Nhôm')
insert into BangChatLieu(MaChatLieu,TenChatLieu) values(N'MCL07',N'Đồng')