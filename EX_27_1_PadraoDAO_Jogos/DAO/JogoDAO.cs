using EX_27_1_PadraoDAO_Jogos.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace EX_27_1_PadraoDAO_Jogos.DAO

{
    public class JogoDAO : PadraoDAO<JogoViewModel>
    {
        protected override SqlParameter[] CriaParametros(JogoViewModel jogo)
        {
            SqlParameter[] parametros =
            {
                new SqlParameter("id", jogo.Id),
                new SqlParameter("descricao", jogo.Descricao),
                new SqlParameter("categoriaId", jogo.CategoriaID),
                new SqlParameter("data_aquisicao",jogo.DataAquisicao),
                new SqlParameter("valor_locacao",jogo.Valor)
            };

            return parametros;
        }

        protected override JogoViewModel MontaModel(DataRow registro)
        {
            JogoViewModel jogo = new JogoViewModel();
            jogo.Id = Convert.ToInt32(registro["id"]);
            jogo.Descricao = registro["descricao"].ToString();
            jogo.CategoriaID = Convert.ToInt32(registro["categoriaId"]);
            jogo.Valor = Convert.ToDouble(registro["valor)locacao"]);
            jogo.DataAquisicao = Convert.ToDateTime(registro["data_aquisicao"]);

            if (registro.Table.Columns.Contains("DescricaoCategoria"))
                jogo.DescricaoCategoria = registro["DescricaoCategoria"].ToString();

            return jogo;
        }

        protected override void SetTabela()
        {
            Tabela = "jogos";
            NomeSpListagem = "spListagemJogos";
        }
    }
}

/*
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
 */
