using SCP.CrossCutting.MapModels.Cargo;
using System;

namespace SCP.CrossCutting.MapModels.ProfissaoVinculo
{
    public class ProfissaoVinculoModel
    {
        public int Id { get; set; }
        public int PessoaFisicaId { get; set; }
        public int ProfissaoId { get; set; }
        public int? CargoId { get; set; }

        public string Salario { get; set; }
        public DateTime DthInicio { get; set; }
        public DateTime? DthDesligamento { get; set; }
        public DateTime DthExclusao { get; set; }

        public CargoModel Cargo { get; set; }
    }
}
