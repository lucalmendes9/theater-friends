--------------- CREATE PROC'S PRAD�O ---------------

create procedure spDelete
(@id int, @tabela varchar(max)) as
begin
	declare @sql varchar(max);
	set @sql = ' delete ' + @tabela +
			   ' where id = ' + cast(@id as varchar(max))
	exec(@sql)
end
GO

create procedure spConsulta
(@id int, @tabela varchar(max)) as
begin
	declare @sql varchar(max);
	set @sql = 'select * from ' + @tabela +
			   ' where id = ' + cast(@id as varchar(max))
	exec(@sql)
end
GO

create procedure spListagem
(@tabela varchar(max), @ordem varchar(max)) as
begin
	exec('select * from ' + @tabela +
		 ' order by ' + @ordem)
end
GO


--------------- CREATE PROC'S INSERT ---------------

--Insert new Costumer
create procedure spInsert_Costumer
(@id int, @name varchar(max), @email varchar(max), @password varchar(max), @created_at date) as
begin
	insert into Costumer("name", email, "password", created_at)
	values (@name, @email, @password, @created_at)
end
GO


--insert new Employer
create procedure spInsert_Employer
(@id int,@name varchar(max), @email varchar(max), @password varchar(max), @employer_role varchar(20), @hired_at date) as
begin
	insert into Employer("name", email, "password", employer_role, hired_at)
	values (@name, @email, @password, @employer_role,@hired_at)
end
GO


--insert new Theater
create procedure spInsert_Theaters
(@id int, @description varchar, @localization_id int, @open_hour varchar, @close_hour varchar, @work_days int) as
begin
	insert into Theaters ("description", localization_id, open_hour, close_hour, work_days)
	values (@description, @localization_id, @open_hour, @close_hour, @work_days)
end
go


--Insert new Room
create procedure spInsert_Rooms
(@id int,@name varchar(max), @seats int, @theaters_id int) as
begin
	insert into Rooms("name", seats, theaters_id)
	values (@name, @seats, @theaters_id)
end
GO


--Insert new Movie
create procedure spInsert_Movies
(@id int, @description varchar, @cover varbinary(max), @type varchar, @length int, @min_age int, @language varchar(max), @subtitle bit) as
begin
	insert into Movies ("description", cover, "type", "length", min_age, "language", subtitle)
	values (@description, @cover, @type, @length, @min_age, @language, @subtitle)
end
go


--------------- CREATE PROC'S UPDATE ---------------

--Alter a costumer
create procedure spUpdate_Costumer
(@id int, @name varchar(max), @email varchar(max), @password varchar(max), @created_at date) as
begin
	update Costumer set
		"name" = @name, email = @email, "password" = @password
	where id = @id
end
GO


--Alter an employer
create procedure spUpdate_Employer
(@id int, @name varchar(max), @email varchar(max), @password varchar(max), @employer_role varchar(max),@created_at date) as
begin
	update Employer set
		"name" = @name, email = @email, "password" = @password, employer_role = @employer_role
	where id = @id
end
GO


--Alter a theater
create procedure spUpdate_Theaters
(@id int, @description varchar, @localization_id int, @open_hour varchar, @close_hour varchar, @work_days int) as
begin
	update Theaters set
		"description" = @description, localization_id = @localization_id, open_hour = @open_hour, close_hour = @close_hour, work_days = @work_days
	where id = @id
end
go


--Insert new Room
create procedure spUpdate_Rooms
(@id int,@name varchar(max), @seats int, @theaters_id int) as
begin
	update Rooms set
		"name" = @name, seats = @seats, theaters_id = @theaters_id
	where id = @id
end
GO


--Alter a Movie
create procedure spUpdate_Movies
(@id int, @description varchar, @cover varbinary(max), @type varchar, @length int, @min_age int, @language varchar(max), @subtitle bit) as
begin
	update Movies set
		"description" = @description, cover = @cover, "type" = @type, "length" = @length, min_age,
		"language" = @language, subtitle = @subtitle
	where id = @id
end
go


--Criar login
create procedure spLogin
( @email varchar(max), @pass varchar(max), @tabela varchar(max) ) as
begin
	declare @sql varchar(1000);
	set @sql = ' where ';
	exec('select * from ' + @tabela +
		 ' where "email" = ''' + @email + ''' and "password" = '''+ @pass +''' ' )
end
go

------------------------------ TESTING AREA ------------------------------
exec spInsert_Costumer 1, 'Heitor', 'heitor@gmail.com', 'japones', '10/10/2020'
exec spInsert_Costumer 2, 'Jo�o', 'joao@gmail.com', 'joaozinho', '08/08/2020'
select * from Costumer