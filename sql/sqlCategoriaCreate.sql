create table categorias
(
	[id] [int] not null primary key,
	[descricao] [varchar](50) Null
)
GO
insert into categorias (id, descricao) values (1, 'Aventura')
GO
insert into categorias (id, descricao) values (2, 'Corrida')
GO
insert into categorias (id, descricao) values (3, 'Ação')
GO
insert into categorias (id, descricao) values (4, 'Puzzle')
GO
insert into categorias (id, descricao) values (5, 'Cotidiano')
GO

select j.id, j.descricao as NomeDoJogo,c.descricao as categoria,j.valor_locacao,j.data_aquisicao from categorias as c inner join jogos j on j.categoriaID = c.id

select j.id, j.descricao as NomeDoJogo,c.descricao as categoria,j.valor_locacao,j.data_aquisicao from jogos j inner join categorias as c on j.categoriaID = c.id