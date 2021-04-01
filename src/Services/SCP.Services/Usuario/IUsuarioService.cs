using SCP.CrossCutting.MapModels.Usuario;
using System.Threading.Tasks;

namespace SCP.Services.Usuario
{
    public interface IUsuarioService
    {
        Task<UsuarioModel> Get(string username, string senha);
    }
}
