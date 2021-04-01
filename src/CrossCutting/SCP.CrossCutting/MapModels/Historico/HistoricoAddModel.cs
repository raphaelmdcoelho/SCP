using System;

namespace SCP.CrossCutting.MapModels.Historico
{
    public class HistoricoAddModel
    {
        public int PessoaId { get; set; }
        public int UsuarioId { get; set; }

        public char Acao { get; set; }
        public DateTime DthRegistro { get; set; }
    }
}
