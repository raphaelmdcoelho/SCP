using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCP.CrossCutting.MapModels.Historico;
using SCP.Services.Historico;
using System;
using System.Threading.Tasks;

namespace SCP.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class HistoricoController : ControllerBase
    {
        private readonly IHistoricoService _historicoService;

        public HistoricoController(IHistoricoService historicoService)
        {
            _historicoService = historicoService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] HistoricoAddModel model)
        {
            try
            {
                return new OkObjectResult(await _historicoService.Add(model));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(
                    new ResponseHistoricoAddModel { Historico = null, Message = ex.Message, Success = false }
                    );
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _historicoService.GetAll();

                if (result != null)
                    return new OkObjectResult(result);

                return NotFound();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
