using SCP.CrossCutting.MapModels.Response;

namespace SCP.CrossCutting.MapModels.PessoaVinculo
{
    public class ResponsePessoaVinculoAddModel : ResponseModel
    {
        public PessoaVinculoModel PessoaVinculo { get; set; }
    }
}