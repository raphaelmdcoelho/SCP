using SCP.CrossCutting.MapModels.Midia;

namespace SCP.CrossCutting.MapModels.Documento
{
    public class DocumentoUpdateModel
    {
        public int Id { get; set; }

        public int MidiaId { get; set; }
        public int PessoaId { get; set; }

        public int Tipo { get; set; }
        public string DthRegistro { get; set; }
        public string DthExclusao { get; set; }
        public bool IsAtivo { get; set; }

        public MidiaModel Midia { get; set; }
    }
}
