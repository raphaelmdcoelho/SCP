using SCP.CrossCutting.MapModels.Documento;

namespace SCP.CrossCutting.MapModels.Midia
{
    public class MidiaModel
    {
        public string Nome { get; set; }
        public string Conteudo { get; set; }
        public string Extensao { get; set; }

        public DocumentoModel Documento { get; set; }

        public string NomeCompleto
        {
            get { return $"{Nome}.{Extensao}"; }
        }
    }
}
