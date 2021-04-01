using SCP.CrossCutting.MapModels.Pessoa;

namespace SCP.CrossCutting.MapModels.Localizacao.Endereco
{
    public class EnderecoModel
    {
        public int Id { get; set; }

        public int EstadoId { get; set; }
        public int CidadeId { get; set; }
        public int PessoaId { get; set; }

        public bool IsCorrespondencia { get; set; }
        public string Logradouro { get; set; }
        public string NumeroPorta { get; set; }
        public string CEP { get; set; }
        public string Uf { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }

        //public EstadoModel Estado { get; set; }
        //public CidadeModel Cidade { get; set; }
        public PessoaModel Pessoa { get; set; }
    }
}
