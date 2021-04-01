using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCP.CrossCutting.MapModels.PessoaJuridica;
using SCP.Services.PessoaJuridica;
using System;
using System.Threading.Tasks;

namespace SCP.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class PessoaJuridicaController : ControllerBase
    {
        private readonly IPessoaJuridicaService _pessoaJuridicaService;

        public PessoaJuridicaController(IPessoaJuridicaService pessoaJuridicaService)
        {
            _pessoaJuridicaService = pessoaJuridicaService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PessoaJuridicaAddModel model)
        {
            try
            {
                return new OkObjectResult( await _pessoaJuridicaService.Add(model));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(
                    new ResponsePessoaJuridicaAddModel { PessoaJuridica = null, Message = ex.Message, Success = false }
                    );
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PessoaJuridicaUpdateModel model)
        {
            try
            {
                return new OkObjectResult(await _pessoaJuridicaService.Update(model));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(
                    new ResponsePessoaJuridicaAddModel { PessoaJuridica = null, Message = ex.Message, Success = false }
                    );
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _pessoaJuridicaService.GetAll();

                if(result != null)
                    return new OkObjectResult(result);

                return NotFound();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return new OkObjectResult( await _pessoaJuridicaService.Get(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                return new OkObjectResult( await _pessoaJuridicaService.Remove(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
