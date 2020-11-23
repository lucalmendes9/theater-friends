--------------- CREATE PROC'S PRADÃO ---------------

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
	values (@name, @email, @password, @employer_role, @hired_at)
end
GO


--insert new Theater
alter procedure spInsert_Theaters
(@id int, @description varchar(max), @localization_id int, @open_hour varchar(max), @close_hour varchar(max), @work_days int) as
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
alter procedure spInsert_Movies
(@id int, @description varchar(max), @cover varbinary(max), @type varchar(max), @length int, @min_age int, @language varchar(max), @subtitle bit) as
begin
	insert into Movies ("description", cover, "type", "length", min_age, "language", subtitle)
	values (@description, @cover, @type, @length, @min_age, @language, @subtitle)
end
go

--Insert new Localization
create procedure spInsert_Localization
(@id int,@phone varchar(max), @address varchar(max), @number int, @neighbourhood varchar(max),
 @city varchar(max),@state varchar(max)) as
begin
	insert into Localization(phone, "address", number, neighbourhood, city, "state")
	values (@phone, @address, @number, @neighbourhood, @city, @state)
end


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
alter procedure spUpdate_Theaters
(@id int, @description varchar(max), @localization_id int, @open_hour varchar(max), @close_hour varchar(max), @work_days int) as
begin
	update Theaters set
		"description" = @description, localization_id = @localization_id, open_hour = @open_hour, close_hour = @close_hour, work_days = @work_days
	where id = @id
end
go


--Alter a room
create procedure spUpdate_Rooms
(@id int,@name varchar(max), @seats int, @theaters_id int) as
begin
	update Rooms set
		"name" = @name, seats = @seats, theaters_id = @theaters_id
	where id = @id
end
GO


--Alter a Movie
alter procedure spUpdate_Movies
(@id int, @description varchar(max), @cover varbinary(max), @type varchar(max), @length int, @min_age int, @language varchar(max), @subtitle bit) as
begin
	update Movies set
		"description" = @description, cover = @cover, "type" = @type, "length" = @length, min_age = @min_age,
		"language" = @language, subtitle = @subtitle
	where id = @id
end
go


--Alter a Localization
create procedure spUpdate_Localization
(@id int,@phone varchar(max), @address varchar(max), @number int, @neighbourhood varchar(max),
 @city varchar(max),@state varchar(max)) as
begin
	update Localization set
		phone = @phone, "address" = @address, number = @number, 
		neighbourhood = @neighbourhood, city = @city, "state" = @state
	where id = @id
end


------------------------------ TESTING AREA ------------------------------
exec spInsert_Costumer 1, 'Heitor', 'heitor@gmail.com', 'japones', '10/10/2020'
exec spInsert_Costumer 2, 'João', 'joao@gmail.com', 'joaozinho', '08/08/2020'

exec spInsert_Employer 1, 'Admin', 'admin@email.com', 'admin1234', 'Administrador','08/08/2020'
exec spInsert_Employer 2, 'João', 'joao@gmail.com', 'joaozinho', 'Pipoqueiro', '08/08/2020'
select * from Employer