using SCP.CrossCutting.MapModels.Midia;
using System;

namespace SCP.CrossCutting.MapModels.Documento
{
    public class DocumentoModel
    {
        public int Id { get; set; }

        public int MidiaId { get; set; }
        public int PessoaId { get; set; }

        public int Tipo { get; set; }
        public DateTime DthRegistro { get; set; }
        public DateTime? DthExclusao { get; set; }
        public bool IsAtivo { get; set; }

        public MidiaModel Midia { get; set; }
    }
}
