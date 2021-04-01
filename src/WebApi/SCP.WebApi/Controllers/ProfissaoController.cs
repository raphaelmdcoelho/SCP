using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCP.CrossCutting.MapModels.Profissao;
using SCP.Services.Profissao;
using System;
using System.Threading.Tasks;

namespace SCP.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class ProfissaoController : ControllerBase
    {
        private readonly IProfissaoService _profissaoService;

        public ProfissaoController(IProfissaoService profissaoService)
        {
            _profissaoService = profissaoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return new OkObjectResult(await _profissaoService.GetAll());
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ProfissaoModel model)
        {
            try
            {
                return new OkObjectResult(await _profissaoService.Add(model));
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                return new OkObjectResult(await _profissaoService.Remove(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
