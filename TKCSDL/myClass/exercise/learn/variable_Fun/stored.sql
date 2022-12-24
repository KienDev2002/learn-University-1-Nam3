
/* tạo thủ tục có đầu vào là mã học sinh, đầu ra là điểm trung bình của học sinh đó*/
CREATE PROCEDURE DiemTrungBinh @mahs nvarchar(5), @dtb float
output
AS
	begin
		select @dtb=round((toan*2+van*2+ly+hoa)/6, 2) from diem where
		MAHS=@mahs
	End
--Gọi thủ tục:
declare @tb float
exec DiemTrungBinh '00001', @tb output
print @tb


-- xếp loại hs: dtb>=8 && dtn >=6.5 => Giỏi , dtb>=7, đtn > =5 => Khá, còn lại là TBinh
go
create procedure XepLoai @mahs nvarchar(5), @xl nvarchar(10) output
as
	begin
			declare  @dtb float, @toan float, @ly float, @van float, @hoa float, @dtn float
			select @toan=toan, @van=van, @hoa=hoa, @ly=ly, @dtb=round((toan*2+van*2+ly+hoa)/6,2) from DIEM where MAHS=@mahs
			set @dtn=@toan
			if @dtn>@van set @dtn=@van
			if @dtn>@hoa set @dtn=@hoa
			if @dtn>@ly set @dtn=@ly
				IF (@dtb>=8 AND @dtn>=6.5) SET @xl=N'Giỏi'
				ELSE IF (@dtb>=7 AND @dtn>=5) SET @xl=N'Khá'
				ELSE SET @xl=N'Trung bình'
	end
--Gọi thủ tục:
declare @xloai nvarchar(10)
exec XepLoai '00008', @xloai output
print @xloai