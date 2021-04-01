using SCP.Domain.Base;
using SCP.Domain.Cargo;
using SCP.Domain.PessoaFisica;
using SCP.Domain.Profissao;
using System;

namespace SCP.Domain.ProfissaoVinculo
{
    public class ProfissaoVinculoEntity : BaseEntity
    {
        public int PessoaFisicaId { get; set; }
        public int ProfissaoId { get; set; }
        public int? CargoId { get; set; }

        public string Salario { get; set; }
        public DateTime DthInicio { get; set; }
        public DateTime? DthDesligamento { get; set; }
        public DateTime DthExclusao { get; set; }

        public PessoaFisicaEntity PessoaFisica { get; set; }
        public ProfissaoEntity Profissao { get; set; }
        public CargoEntity Cargo { get; set; }
    }
}
