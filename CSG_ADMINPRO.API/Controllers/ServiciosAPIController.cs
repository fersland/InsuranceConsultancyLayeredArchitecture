using CSG_ADMINPRO.APLICATION.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CSG_ADMINPRO.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiciosAPIController : Controller
    {
        private readonly IServicioService _servicioService;
        private readonly ILogger<ServiciosAPIController> _logger;

        public ServiciosAPIController(
                    IServicioService servicioService,
                    ILogger<ServiciosAPIController> logger)
        {
            _servicioService = servicioService;
            _logger = logger;
        }

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetAllServicioAPI()
        {
            try
            {
                var lista = await _servicioService.GetAllServicioAsync();

                if(lista == null)
                {
                    _logger.LogWarning("Lista de servicios no encontrada.");
                    return NotFound("Lista no encontrada");
                }

                if(lista.Count() == 0)
                {
                    _logger.LogWarning("Lista de servicios vacia.");
                    return NotFound("Lista vacia");
                }

                _logger.LogInformation("Lista de servicios obtenida correctamente.");
                return Ok(lista);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la lista de servicios.");
                return StatusCode(500, "Error interno del servidor." + ex.Message);
            }
        }

        [HttpGet]
        [Route("Search/{id:int}")]
        public async Task<IActionResult> Show(int id)
        {
            try
            {
                if(id <= 0)
                {
                    _logger.LogWarning("ID no encontrada");
                    return BadRequest("ID no valida.");
                }

                var search = await _servicioService.GetByIdAsync(id);
                
                if(search == null)
                {
                    _logger.LogCritical("ID no encontrada");
                    return NotFound("ID no encontrada");
                }

                _logger.LogInformation("Servicio mostrado correctamente.");
                return Ok(search);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el servicio.");
                return StatusCode(500, "Error interno del servidor." + ex.Message);
            }
        }


    }


}
