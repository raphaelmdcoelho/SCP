namespace SCP.CrossCutting.MapModels.Contato
{
    public class ContatoModel
    {
        public int Id { get; set; }
        public int PessoaId { get; set; }

        public string DDD { get; set; }
        public string Numero { get; set; }
        public char Tipo { get; set; }
    }
}
