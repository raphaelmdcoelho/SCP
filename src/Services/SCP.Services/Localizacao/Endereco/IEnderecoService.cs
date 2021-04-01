using SCP.CrossCutting.MapModels.Localizacao.Endereco;
using System.Threading.Tasks;

namespace SCP.Services.Localizacao.Endereco
{
    public interface IEnderecoService
    {
        Task<int> Add(EnderecoModel model);
    }
}
