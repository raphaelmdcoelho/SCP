using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCP.CrossCutting.MapModels.Cargo;
using SCP.Services.Cargo;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SCP.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CargoController : ControllerBase
    {
        private readonly ICargoService _cargoService;

        public CargoController(ICargoService cargoService)
        {
            _cargoService = cargoService;
        }

        [HttpGet]
        public async Task<IEnumerable<CargoModel>> GetAll()
        {
            try
            {
                return await _cargoService.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<int> Add([FromBody] CargoModel model)
        {
            try
            {
                return await _cargoService.Add(model);
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
                return new OkObjectResult(await _cargoService.Remove(id));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
