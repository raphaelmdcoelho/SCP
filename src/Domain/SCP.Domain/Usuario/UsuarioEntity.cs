using SCP.Domain.Base;
using SCP.Domain.Historico;
using SCP.Domain.Pessoa;
using System.Collections.Generic;

namespace SCP.Domain.Usuario
{
    public class UsuarioEntity : BaseEntity
    {
        public string Username { get; set; }
        public string Senha { get; set; }
        public string Salt { get; set; }
        public string Papel { get; set; }

        public List<HistoricoEntity> Historicos { get; set; }
        public List<PessoaEntity> Pessoas { get; set; }
    }
}
