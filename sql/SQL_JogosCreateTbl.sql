CREATE TABLE jogos
(
	 [id] [int] NOT NULL primary key,
	 [descricao] [varchar](50) NULL,
	 [valor_locacao] [decimal](18, 2) NULL,
	 [data_aquisicao] [datetime] NULL,
	 [categoriaID] [int] NULL
 )
 GO

alter table jogos
	add constraint fk_categoriaID 
	foreign key (categoriaID) references categorias(id)
 
