using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCP.CrossCutting.MapModels.PagedList.PagedListPessoaFisica;
using SCP.CrossCutting.MapModels.PessoaFisica;
using SCP.Services.PessoaFisica;
using System;
using System.Threading.Tasks;

namespace SCP.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //[Authorize]
    public class PessoaFisicaController : ControllerBase
    {
        private readonly IPessoaFisicaService _pessoaFisicaService;

        public PessoaFisicaController(IPessoaFisicaService pessoaFisicaService)
        {
            _pessoaFisicaService = pessoaFisicaService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] PessoaFisicaAddModel model)
        {
            try
            {
                return new OkObjectResult( await _pessoaFisicaService.Add(model));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(
                    new ResponsePessoaFisicaAddModel { PessoaFisica = null, Message = ex.Message, Success = false }
                    );
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] PessoaFisicaUpdateModel model)
        {
            try
            {
                return new OkObjectResult(await _pessoaFisicaService.Update(model));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(
                    new ResponsePessoaFisicaAddModel { PessoaFisica = null, Message = ex.Message, Success = false }
                    );
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _pessoaFisicaService.GetAll();

                if(result != null)
                    return new OkObjectResult(result);

                return NotFound();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("GetAllPagedList")]
        public async Task<IActionResult> GetAllPagedList([FromBody] PagedListPessoaFisica pagedListPessoaFisica)
        {
            try
            {
                var result = await _pessoaFisicaService.GetAllPagedList(pagedListPessoaFisica);

                if (result != null)
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
                return new OkObjectResult( await _pessoaFisicaService.Get(id));
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
                return new OkObjectResult( await _pessoaFisicaService.Remove(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
