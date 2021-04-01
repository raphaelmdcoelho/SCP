using Newtonsoft.Json;
using SCP.CrossCutting.MapModels.Localizacao.Cep;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SCP.Infrastructure.Communication.Base
{
    public abstract class BaseClient
    {
        public HttpClient Client { get; }
        public BaseClient()
        {
            if(Client == null)
            {
                Client = new HttpClient();
            }
        }

        public async Task<string> SendAsync(HttpMethod method, string url)
        {
            try
            {
                var request = new HttpRequestMessage(method, url);

                //Client.DefaultRequestHeaders.Add("token", "");

                var response = await Client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return await response.Content.ReadAsStringAsync();
                }

                return null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
