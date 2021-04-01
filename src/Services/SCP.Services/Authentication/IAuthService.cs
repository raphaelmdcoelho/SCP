using SCP.CrossCutting.MapModels.Usuario;
using System.Threading.Tasks;

namespace SCP.Services.Authentication
{
    public interface IAuthService
    {
        Task<ResponseAddUsuarioModel> Register(UsuarioAddModel usuario, string password);
        Task<bool> UserExists(string username);
        void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        string GetPasswordHash(string password);
    }
}
