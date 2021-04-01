using SCP.CrossCutting.MapModels.Pessoa;
using SCP.CrossCutting.MapModels.PessoaVinculo;
using SCP.CrossCutting.MapModels.ProfissaoVinculo;
using System;
using System.Collections.Generic;

namespace SCP.CrossCutting.MapModels.PessoaFisica
{
    public class PessoaFisicaUpdateModel
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }

        public string PrimeiroNome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DthNascimento { get; set; }
        public char Genero { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Altura { get; set; }
        public string Peso { get; set; }

        public PessoaModel Pessoa { get; set; }

        public List<ProfissaoVinculoModel> Profissoes { get; set; }
        public List<PessoaVinculoModel> EmpresasVinculadas { get; set; }
    }
}
