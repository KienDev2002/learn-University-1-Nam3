


--1. Tạo hàm có đầu vào là lộ trình, đầu ra là số xe, mã trọng tải, số lượng vận tải,
--ngày đi, ngày đến (SoXe, MaTrongTai, SoLuongVT, NgayDi, NgayDen.)
go
create function cau1(@maLoTrinh nvarchar(20))
returns table
as
	return(
		select cthvt.SoXe , cthvt.MaTrongTai , cthvt.SoLuongVT , cthvt.NgayDi , cthvt.NgayDen
		from ChiTietVanTai cthvt
		where cthvt.MaLoTrinh = @maLoTrinh
	)

select * from cau1(N'NT')


--2. Thiết lập hàm có đầu vào là số xe, đầu ra là thông tin về lộ trình
go
create function cau2(@soXeTS nvarchar(10))
returns table
as
	return(
		select lt.MaLoTrinh , lt.TenLoTrinh , lt.DonGia 
		from LoTrinh lt join ChiTietVanTai ctvt on ctvt.MaLoTrinh = lt.MaLoTrinh
		where ctvt.SoXe = @soXeTS
	)
select * from cau2(N'444')
--3.Tạo hàm có đầu vào là trọng tải, đầu ra là các số xe có trọng tải quy định lớn hơn hoặc bằng 
--trọng tải đó  
go
create function cau3(@TrongTai int)
returns table
as

	return(
		select distinct ctvt.SoXe
		from ChiTietVanTai ctvt join TrongTai tt on tt.MaTrongTai = ctvt.MaTrongTai
		where tt.TrongTaiQD >= @TrongTai
	)


select * from cau3(4)


--4. Tạo hàm có đầu vào là trọng tải và mã lộ trình, đầu ra là số lượng xe có trọng tải quy định 
--lớn hơn hoặc bằng trọng tải đó
go 
create function cau4(@TrongTai int ,@maLoTrinh nvarchar(20) )
returns int
as
begin
	declare @SLxe int
	select @SLxe = COUNT(distinct ctvt.SoXe)
	from ChiTietVanTai ctvt join TrongTai tt on tt.MaTrongTai = ctvt.MaTrongTai
		where tt.TrongTaiQD >= @TrongTai and ctvt.MaLoTrinh = @maLoTrinh
	return @SLxe
end
select dbo.cau4(5,N'NT')


--5. Tạo thủ tục có đầu vào Mã lộ trình đầu ra là số lượng xe thuộc lộ trình đó.
go
create procedure cau5 @maLoTrinh nvarchar(20), @SLxe int output
as
begin
	select @SLxe =  COUNT(distinct ctvt.SoXe)
		from ChiTietVanTai ctvt
		where ctvt.MaLoTrinh = @maLoTrinh
end

declare @soLuongXe int
exec cau5 'NT', @soLuongXe output
print N' Số xe thuộc lộ trình NT là: ' +  convert(varchar(100),@soLuongXe) 


--6. Tạo thủ tục có đầu vào là mã lộ trình, năm vận tải, đầu ra là số tiền theo mã lộ trình và năm vận tải đó
go
create procedure cau6 @maLoTrinh nvarchar(20), @namVanTai int , @TT money output
as
begin
	select @TT =  SUM(lt.DonGia)
	from ChiTietVanTai ctvt join LoTrinh lt on lt.MaLoTrinh = ctvt.MaLoTrinh
	where lt.MaLoTrinh = @maLoTrinh and Year(ctvt.NgayDi) = @namVanTai
end

declare @sotien money
exec cau6 N'NT' , 2014 , @sotien output
print @sotien


--7. Tạo thủ tục có đầu vào là số xe, năm vận tải, đầu ra là số tiền theo số xe và năm vận tải đó
go
create procedure cau7 @soXe int, @namVanTai int , @TT money output
as
begin
	select SUM(lt.DonGia)
	from ChiTietVanTai ctvt join LoTrinh lt on lt.MaLoTrinh = ctvt.MaLoTrinh
	where ctvt.SoXe = @soXe and Year(ctvt.NgayDi) = @namVanTai
end


declare @sotien money
exec cau7 333 , 2014 , @sotien output
print @sotien


--8. Tạo thủ tục có đầu vào là mã trọng tải, đầu ra là số lượng xe vượt quá trọng tải quy định 
--của mã trọng tải đó.
go 
create procedure cau8 @TrongTai int , @sl int output
as
begin
	select @sl = COUNT(distinct ctvt.SoXe)
	from ChiTietVanTai ctvt join TrongTai tt on tt.MaTrongTai = ctvt.MaTrongTai
		where tt.TrongTaiQD > @TrongTai
end

declare @soluong int
exec cau8 8, @soluong output
print @soluong