using SCP.CrossCutting.MapModels.Historico;
using SCP.CrossCutting.MapModels.Pessoa;
using System.Collections.Generic;

namespace SCP.CrossCutting.MapModels.Usuario
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
        public string Salt { get; set; }
        public string Papel { get; set; }

        public List<HistoricoModel> Historicos { get; set; }
        public List<PessoaModel> Pessoas { get; set; }
    }
}
