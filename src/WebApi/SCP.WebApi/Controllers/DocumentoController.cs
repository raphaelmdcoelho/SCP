using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCP.CrossCutting.MapModels.Documento;
using SCP.Services.Documento;
using System;
using System.Threading.Tasks;

namespace SCP.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class DocumentoController : ControllerBase
    {
        private readonly IDocumentoService _documentoService;

        public DocumentoController(IDocumentoService documentoService)
        {
            _documentoService = documentoService;
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] DocumentoAddModel model)
        {
            try
            {
                return new OkObjectResult(await _documentoService.Add(model));
            }
            catch (Exception ex)
            {
                return new OkObjectResult(
                    new ResponseDocumentoAddModel { Documento = null, Message = ex.Message, Success = false }
                    );
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _documentoService.GetAll();

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
                return new OkObjectResult(await _documentoService.Get(id));
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
                return new OkObjectResult(await _documentoService.Remove(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
