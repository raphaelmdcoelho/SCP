using SCP.CrossCutting.MapModels.Localizacao.Cep;
using System.Threading.Tasks;

namespace SCP.Services.Localizacao.Cep
{
    public interface ICepService
    {
        Task<CosultaCep> GetLocalizacaoByCep(string cep);
    }
}
