using System;

namespace EX_27_1_PadraoDAO_Jogos.Models
{
    public class ErrorViewModel
    {
        public ErrorViewModel() { }
        public ErrorViewModel(string erro)
        {
            this.Erro = erro;
        }

        public string Erro { get; set; }

        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
