using SCP.CrossCutting.MapModels.Localizacao.Cep;
using System.Threading.Tasks;

namespace SCP.Infrastructure.Communication.Localizacao
{
    public interface ILocalizacaoClient
    {
        Task<CosultaCep> GetLocalizacaoByCep(string cep);
    }
}
