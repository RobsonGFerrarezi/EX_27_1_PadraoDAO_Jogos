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
GO
(@tabela varchar(max))
as
begin
 exec('select isnull(max(id) +1, 1) as MAIOR from '
 +@tabela)
end
GO