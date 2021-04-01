using Newtonsoft.Json;
using SCP.CrossCutting.MapModels.Localizacao.Cep;
using SCP.Infrastructure.Communication.Base;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SCP.Infrastructure.Communication.Localizacao
{
    public class LocalizacaoClient : BaseClient, ILocalizacaoClient
    {
        private HttpClient _client;
        public LocalizacaoClient() : base()
        {
            _client = Client;
        }

        public async Task<CosultaCep> GetLocalizacaoByCep(string cep)
        {
            try
            {
                StringBuilder url = new StringBuilder();

                url.Append("https://viacep.com.br/ws/");
                url.Append($"{cep}/json/");

                var result = await SendAsync(HttpMethod.Get, url.ToString());

                if(result == null)
                {
                    return new CosultaCep();
                }

                return JsonConvert.DeserializeObject<CosultaCep>(result);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
