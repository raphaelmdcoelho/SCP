using SCP.Domain.Base;
using SCP.Domain.Pessoa;
using SCP.Domain.PessoaVinculo;
using System.Collections.Generic;

namespace SCP.Domain.PessoaJuridica
{
    public class PessoaJuridicaEntity : BaseEntity
    {
        public int PessoaId { get; set; }

        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public char CNPJ { get; set; }

        public PessoaEntity Pessoa { get; set; }

        public List<PessoaVinculoEntity> Socios { get; set; }
    }
}
