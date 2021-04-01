using SCP.Domain.Base;
using SCP.Domain.PessoaFisica;
using SCP.Domain.PessoaJuridica;
using System;

namespace SCP.Domain.PessoaVinculo
{
    public class PessoaVinculoEntity : BaseEntity
    {
        public int PessoaFisicaId { get; set; }
        public int PessoaJuridicaId { get; set; }

        public int TipoVinculo { get; set; }
        public DateTime DthRegistro { get; set; }
        public DateTime DthExclusao { get; set; }
        public bool IsAtivo { get; set; }

        public PessoaFisicaEntity PessoaFisica { get; set; }
        public PessoaJuridicaEntity PessoaJuridica { get; set; }
    }
}
