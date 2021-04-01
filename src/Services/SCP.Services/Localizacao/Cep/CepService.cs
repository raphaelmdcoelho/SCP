using SCP.CrossCutting.MapModels.Localizacao.Cep;
using SCP.Infrastructure.Communication.Localizacao;
using System;
using System.Threading.Tasks;

namespace SCP.Services.Localizacao.Cep
{
    public class CepService : ICepService
    {
        private readonly ILocalizacaoClient _localizacaoClient;
        public CepService(ILocalizacaoClient localizacaoClient)
        {
            _localizacaoClient = localizacaoClient;
        }
        public async Task<CosultaCep> GetLocalizacaoByCep(string cep)
        {
            try
            {
                return await _localizacaoClient.GetLocalizacaoByCep(cep);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
