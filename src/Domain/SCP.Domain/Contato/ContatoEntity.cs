using SCP.Domain.Base;
using SCP.Domain.Pessoa;

namespace SCP.Domain.Contato
{
    public class ContatoEntity: BaseEntity
    {
        public int PessoaId { get; set; }

        public string DDD { get; set; }
        public string Numero { get; set; }
        public char Tipo { get; set; }

        public PessoaEntity Pessoa { get; set; }
    }
}
