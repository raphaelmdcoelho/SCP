using SCP.CrossCutting.MapModels.Contato;
using SCP.CrossCutting.MapModels.Documento;
using SCP.CrossCutting.MapModels.Localizacao.Endereco;
using System;
using System.Collections.Generic;

namespace SCP.CrossCutting.MapModels.Pessoa
{
    public class PessoaModel
    {
        public int? IdUsuario { get; set; }

        public int Tipo { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime DthCriacao { get; set; }
        public DateTime? DthExclusao { get; set; }

        public List<EnderecoModel> Enderecos { get; set; }
        public List<ContatoModel> Contatos { get; set; }
        public List<DocumentoModel> Documentos { get; set; }
    }
}
