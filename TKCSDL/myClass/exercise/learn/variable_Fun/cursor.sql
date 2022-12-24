


declare diemsv cursor for select MaSV from dbo.KetQua 
open diemsv
declare @masv nvarchar(20), @diemthi float, @min float
select @min = max(kq.DiemThi) from dbo.KetQua kq
	fetch next from diemsv into @masv
		while (@@FETCH_STATUS=0)
			begin
				select @diemthi = kq.DiemThi
						from dbo.KetQua kq
						where @masv = MaSV
				
				if(@min > @diemthi)
					begin
						set @min = @diemthi
					end
				fetch next from diemsv into @masv
			end
print N'Điểm thấp nhất là: ' +  convert(varchar(100),@min) 
close diemsv; deallocate diemsv