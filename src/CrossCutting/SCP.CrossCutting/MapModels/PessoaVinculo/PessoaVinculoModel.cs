using System;

namespace SCP.CrossCutting.MapModels.PessoaVinculo
{
    public class PessoaVinculoModel
    {
        public int Id { get; set; }

        public int PessoaFisicaId { get; set; }
        public int PessoaJuridicaId { get; set; }

        public int TipoVinculo { get; set; }
        public DateTime DthRegistro { get; set; }
        public DateTime DthExclusao { get; set; }
        public bool IsAtivo { get; set; }
    }
}
