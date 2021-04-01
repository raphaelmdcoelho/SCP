using SCP.Domain.Base;
using SCP.Domain.Midia;
using SCP.Domain.Pessoa;
using System;

namespace SCP.Domain.Documento
{
    public class DocumentoEntity : BaseEntity
    {
        public int MidiaId { get; set; }
        public int PessoaId { get; set; }

        public int Tipo { get; set; }
        public DateTime DthRegistro { get; set; }
        public DateTime? DthExclusao { get; set; }
        public bool IsAtivo { get; set; }

        public PessoaEntity Pessoa { get; set; }
        public MidiaEntity Midia { get; set; }

        
    }
}
