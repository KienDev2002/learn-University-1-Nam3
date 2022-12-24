

DECLARE cs CURSOR FOR SELECT MAHS FROM DSHS
OPEN cs
DECLARE @mahs nvarchar(5), @dtb float, @toan float, @ly float, @van float, @hoa float, @dtn float
FETCH NEXT FROM cs into @mahs
	WHILE @@FETCH_STATUS=0
		BEGIN
			declare @xl nchar(25)
			select @toan=toan, @van=van, @hoa=hoa, @ly=ly, @dtb=round((toan*2+van*2+ly+hoa)/6,2) from DIEM where MAHS=@mahs
			set @dtn=@toan
			if @dtn>@van set @dtn=@van
			if @dtn>@hoa set @dtn=@hoa
			if @dtn>@ly set @dtn=@ly
				IF (@dtb>=8 AND @dtn>=6.5) SET @xl=N'Giỏi'
				ELSE IF (@dtb>=7 AND @dtn>=5) SET @xl=N'Khá'
				ELSE SET @xl=N'Trung bình'
			Update dshs set XepLoai=@xl where MAHS=@mahs
			FETCH NEXT FROM cs into @mahs
		END
CLOSE cs
DEALLOCATE cs


-- tại sao tránh sử dụng con trỏ khi nào.