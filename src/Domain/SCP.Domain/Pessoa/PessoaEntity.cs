using SCP.Domain.Base;
using SCP.Domain.Contato;
using SCP.Domain.Documento;
using SCP.Domain.Historico;
using SCP.Domain.Localizacao.Endereco;
using SCP.Domain.PessoaFisica;
using SCP.Domain.PessoaJuridica;
using SCP.Domain.Usuario;
using System;
using System.Collections.Generic;

namespace SCP.Domain.Pessoa
{
    public class PessoaEntity : BaseEntity
    {
        public int? UsuarioId { get; set; }

        public int Tipo { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime DthCriacao { get; set; }
        public DateTime? DthExclusao { get; set; }
        
        public PessoaFisicaEntity PessoaFisica { get; set; }
        public PessoaJuridicaEntity PessoaJuridica { get; set; }
        public UsuarioEntity Usuario { get; set; }
        
        public List<HistoricoEntity> Historicos { get; set; }
        public List<EnderecoEntity> Enderecos { get; set; }
        public List<ContatoEntity> Contatos { get; set; }
        public List<DocumentoEntity> Documentos { get; set; }
    }
}
