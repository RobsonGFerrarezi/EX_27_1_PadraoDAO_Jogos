create or alter procedure spListagemCategorias
as
begin
	select * from categorias
end
GO

create or alter procedure spInclui_categorias
(
	@id int,
	@descricao varchar(max)
)
as
begin
	insert into categorias
		(id, descricao)
	values (@id, @descricao)
end

create or alter procedure spUpdate_Categorias
(
	@id int,
	@descricao varchar(max)
)
as
begin
	update jogos set
		descricao = @descricao
	where id = @id
end

