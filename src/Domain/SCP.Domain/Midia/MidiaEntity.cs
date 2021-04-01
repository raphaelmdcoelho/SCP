using SCP.Domain.Base;
using SCP.Domain.Documento;

namespace SCP.Domain.Midia
{
    public class MidiaEntity : BaseEntity
    {
        public string Nome { get; set; }
        public string Conteudo { get; set; }
        public string Extensao { get; set; }

        public DocumentoEntity Documento { get; set; }
    }
}
