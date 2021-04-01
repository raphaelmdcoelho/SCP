using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCP.Services.Localizacao.Cep;
using System;
using System.Threading.Tasks;

namespace SCP.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocalizacaoController : ControllerBase
    {
        private readonly ICepService _cepService;

        public LocalizacaoController(ICepService cepService)
        {
            _cepService = cepService;
        }

        [AllowAnonymous]
        [HttpGet("{cep}")]
        public async Task<IActionResult> GetLocalizacaoByCep(string cep)
        {
            try
            {
                var result = await _cepService.GetLocalizacaoByCep(cep);

                if(result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
