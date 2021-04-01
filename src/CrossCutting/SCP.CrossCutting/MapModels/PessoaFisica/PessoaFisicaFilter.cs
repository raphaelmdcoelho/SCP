using System;

namespace SCP.CrossCutting.MapModels.PessoaFisica
{
    public class PessoaFisicaFilter
    {

        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime? DthNascimento { get; set; }
        public char? Genero { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
    }
}
