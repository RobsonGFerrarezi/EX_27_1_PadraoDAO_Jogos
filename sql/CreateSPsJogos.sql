create procedure spDelete
(
 @id int ,
 @tabela varchar(max)
)
as
begin
	 declare @sql varchar(max);
	 set @sql = ' delete ' + @tabela +
		' where id = ' + cast(@id as varchar(max))
	 exec(@sql)
end
GO

create procedure spConsulta
(
	 @id int ,
	 @tabela varchar(max)
)
as
begin
	 declare @sql varchar(max);
	 set @sql = 'select * from ' + @tabela +
		' where id = ' + cast(@id as varchar(max))
	 exec(@sql)
end
GO

create procedure spListagemJogos
(
	 @tabela varchar(max),
	 @ordem varchar(max)
)
as
begin
	 exec('select * from ' + @tabela +
		' order by ' + @ordem)
end
GOcreate procedure spProximoId
(@tabela varchar(max))
as
begin
 exec('select isnull(max(id) +1, 1) as MAIOR from '
 +@tabela)
end
GOcreate procedure spInsert_Jogos(	@id int,	@descricao varchar(max),	@valor_locacao decimal(10,2),	@data_aquisicao datetime,	@categoriaId int)asbegin	insert into jogos 		(id, descricao, valor_locacao, data_aquisicao, categoriaID)	values		(@id, @descricao, @valor_locacao, @data_aquisicao, @categoriaId)endGOcreate or alter procedure spUpdate_Jogos(	@id int,	@descricao varchar(max),	@valor_locacao decimal(10,2),	@data_aquisicao datetime,	@categoriaId int )asbegin	update jogos set		descricao = @descricao,		valor_locacao = @valor_locacao,		data_aquisicao = @data_aquisicao,		categoriaID = @categoriaId	where id = @idendGO