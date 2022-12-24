
create function UF_isOdd(@Num int)
returns nvarchar(20)
as
begin
	if(@Num % 2 = 0)
		return N'Là số chẵn'
	else
		return N'Là số lẻ'
	return N'Không xác định'
end


alter function UF_isOdd(@Num int)
returns nvarchar(20)
as
begin
	if(@Num % 2 = 0)
		return N'Là số chẵn'
	else
		return N'Là số lẻ'
	return N'Không xác định'
end

go

create function Age(@year datetime)
returns int
as
begin
	declare @age int
	set @age = YEAR(GETDATE()) - YEAR(@year)
	return @age
end

select dbo.UF_isOdd(dbo.Age(hs.NGAYSINH)) from dbo.DSHS hs

select * from dbo.DSHS






Create function sinhkhoa () returns char(6) As
Begin 
	declare @max int 
	select 
	@max = max(cast(substring(masv,3,4) as int)) + 1
	from sinhvien 
	declare @s char(8)
	set @s = '000' + rtrim(cast(@max as char(4)))
	set @s = 'BA' + right(@s,4)
	return @s
end

--
create function layDSHS (@mahs nvarchar(5))
returns table
as

	return (
		select dshs.MAHS , dshs.TEN
		from DSHS dshs
		where dshs.MAHS = @mahs
	)

select * from layDSHS('0008') 

select * from DSHS


