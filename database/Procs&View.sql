create view vw_ListaCinemas as
select t."description", l."address", l.phone , l.city, l."state"
from Theaters t
inner join Localization l on l.id = t.localization_id 

create proc sp_ListagemCinemas as
begin
	select * from vw_ListaCinemas
end
go

exec sp_ListagemCinemas

------------------------------
--drop view vw_Exibicao
create view vw_Exibicao as
select e.movie_id, l.city as 'Cidade', t."description" as 'Cinema', se."start_date" as 'Inicio'
from Exhibition e
inner join Schedule_Exhibition se on e.id = se.exhibition_id
inner join Movies m on m.id = e.movie_id
inner join Rooms r on r.id = e.room_id
inner join Theaters t on t.id = r.theaters_id
inner join Localization l on l.id = t.localization_id

--drop proc sp_ListagemExibicao
create proc sp_ListagemExibicao
(@id int) as
begin
	select * from vw_Exibicao
	where vw_Exibicao.movie_id = @id
end
 
 exec sp_ListagemExibicao 1
 -------------------------
 create view vw_ListagemFilmes as
 select m.id, m."name", m."type", m."length", m."language", m.subtitle
 from Movies m

 create proc sp_ListagemFilmes as
 begin
	select * from vw_ListagemFilmes	
 end

 -------------------------

 select * from Employer