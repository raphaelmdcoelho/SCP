using SCP.Domain.Base;
using SCP.Domain.Pessoa;
using SCP.Domain.Usuario;
using System;

namespace SCP.Domain.Historico
{
    public class HistoricoEntity : BaseEntity
    {
        public int PessoaId { get; set; }
        public int UsuarioId { get; set; }

        public char Acao { get; set; }
        public DateTime DthRegistro { get; set; }

        public PessoaEntity Pessoa { get; set; }
        public UsuarioEntity Usuario { get; set; }
    }
}
