using EX_27_1_PadraoDAO_Jogos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EX_27_1_PadraoDAO_Jogos.DAO
{
    public class CategoriaDAO :  PadraoDAO<CategoriaViewModel>
    {
        protected override SqlParameter[] CriaParametros(CategoriaViewModel categoria)
        {
            SqlParameter[] parametro =
            {
                new SqlParameter("id",categoria.Id),
                new SqlParameter("descricao",categoria.Descricao)
            };

            return parametro;
        }

        protected override CategoriaViewModel MontaModel(DataRow registro)
        {
            CategoriaViewModel categoria = new CategoriaViewModel();
            categoria.Id = Convert.ToInt32(registro["id"]);
            categoria.Descricao = registro["descricao"].ToString();

            return categoria;
        }

        protected override void SetTabela()
        {
            Tabela = "categorias";
            NomeSpListagem = "spListagemCategorias";
        }

        public List<CategoriaViewModel> Lista()
        {

            DataTable tabela = HelperDAO.ExecutaProcSelect("spListagemCategorias", null);
            List<CategoriaViewModel> retorno = new List<CategoriaViewModel>();

            foreach (DataRow registro in tabela.Rows)
            {
                retorno.Add(MontaModel(registro));
            }

            return retorno;
        }
    }
}
/*
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


create procedure spListagemCategorias
as
begin
	select * from categorias
end
GO

*/