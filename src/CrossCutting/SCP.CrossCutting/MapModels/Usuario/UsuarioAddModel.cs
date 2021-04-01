namespace SCP.CrossCutting.MapModels.Usuario
{
    public class UsuarioAddModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
        public string Salt { get; set; }
        public string Papel { get; set; }
    }
}
