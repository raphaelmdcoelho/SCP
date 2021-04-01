using SCP.Domain.Base;
using SCP.Domain.Pessoa;

namespace SCP.Domain.Localizacao.Endereco
{
    public class EnderecoEntity : BaseEntity
    {
        public int PessoaId { get; set; }

        public bool IsCorrespondencia { get; set; }
        public string Logradouro { get; set; }
        public string NumeroPorta { get; set; }
        public string Cep { get; set; }
        public string Uf { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }

        public PessoaEntity Pessoa { get; set; }
    }
}
