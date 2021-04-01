using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCP.CrossCutting.MapModels.PessoaVinculo;
using SCP.Services.PessoaVinculo;
using System;
using System.Threading.Tasks;

namespace SCP.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class PessoaVinculoController : ControllerBase
    {
        private readonly IPessoaVinculoService _pessoaVinculoService;

        public PessoaVinculoController(IPessoaVinculoService pessoaVinculoService)
        {
            _pessoaVinculoService = pessoaVinculoService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PessoaVinculoAddModel model)
        {
            try
            {
                return new OkObjectResult(await _pessoaVinculoService.Add(model));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(
                    new ResponsePessoaVinculoAddModel { PessoaVinculo = null, Message = ex.Message, Success = false }
                    );
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PessoaVinculoUpdateModel model)
        {
            try
            {
                return new OkObjectResult(await _pessoaVinculoService.Update(model));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(
                    new ResponsePessoaVinculoAddModel { PessoaVinculo = null, Message = ex.Message, Success = false }
                    );
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _pessoaVinculoService.GetAll();

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
                return new OkObjectResult(await _pessoaVinculoService.Get(id));
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
                return new OkObjectResult(await _pessoaVinculoService.Remove(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
