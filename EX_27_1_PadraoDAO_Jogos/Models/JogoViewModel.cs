using System;

namespace EX_27_1_PadraoDAO_Jogos.Models
{
    public class JogoViewModel : PadraoViewModel
    {
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public DateTime DataAquisicao { get; set; }
        public int CategoriaID { get; set; }

        public string DescricaoCategoria { get; set; }
    }
}
