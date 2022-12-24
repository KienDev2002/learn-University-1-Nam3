

Declare @t int, @x int
	Set @t = 0 ; Set @x = 1
While (@x <= 100)
	begin
		if ((@x % 2) = 0)
			set @t = @t + @x
			set @x = @x + 1
	end
Print @tdeclare @gt int , @n int, @i intset @gt = 1; set @n = 10; set @i = 1while(@i <= @n)	begin		set @gt = @gt * @i		set @i = @i + 1	endprint @gt		


















