using SCP.CrossCutting.MapModels.Pessoa;
using SCP.CrossCutting.MapModels.PessoaVinculo;
using System.Collections.Generic;

namespace SCP.CrossCutting.MapModels.PessoaJuridica
{
    public class PessoaJuridicaModel
    {
        public int Id { get; set; }

        public int PessoaId { get; set; }

        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public char CNPJ { get; set; }

        public PessoaModel Pessoa { get; set; }

        public List<PessoaVinculoModel> Socios { get; set; }
    }
}
