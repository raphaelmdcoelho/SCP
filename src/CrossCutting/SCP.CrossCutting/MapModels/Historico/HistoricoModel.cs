using SCP.CrossCutting.MapModels.Pessoa;
using System;

namespace SCP.CrossCutting.MapModels.Historico
{
    public class HistoricoModel
    {
        public int Id { get; set; }

        public int PessoaId { get; set; }
        public int UsuarioId { get; set; }

        public char Acao { get; set; }
        public DateTime DthRegistro { get; set; }

        public PessoaModel Pessoa { get; set; }
    }
}
