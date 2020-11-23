--------------------- TRIGGER -----------------------
--Quando um cinema é excluido, suas salas são também
alter trigger trg_DeleteTheaters
on Theaters instead of delete as
begin
	delete from Rooms
	where theaters_id = (select id from deleted)
	delete from Theaters 
	where id = (select id from deleted)
end

select * from Theaters
select * from Rooms

--------------------- CURSOR -----------------------
--cursor dentro de uma procedure que realiza a busca de clientes por nome
alter proc sp_ProcuraCliente_Cursor 
(@nome varchar(max))as
begin
	declare @costumer_id int, @costumer_name varchar(50), @costumer_email varchar(50)
	declare @search varchar(max) -- variável de procura

	set @search = @nome
	declare cursor_costumer cursor for
	select id, "name", email from Costumer
	where "name" like '%'+@search+'%'

	open cursor_costumer -- abertura do cursor

	FETCH NEXT FROM cursor_costumer
	INTO @costumer_id, @costumer_name, @costumer_email
	while @@fetch_Status = 0 -- enquanto houver registros, faça
	begin
		print 'Código: ' + cast( @costumer_id as varchar) +
			  ' Nome: ' + @costumer_name + ' Email: ' + @costumer_email

		FETCH NEXT FROM cursor_costumer
		INTO @costumer_id, @costumer_name, @costumer_email
	end
	
	close cursor_costumer -- fecha o cursor
	deallocate cursor_costumer -- desaloca o cursor da memória
end


select * from Costumer
exec sp_ProcuraCliente_Cursor 'alb'
