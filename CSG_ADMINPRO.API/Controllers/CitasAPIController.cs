using AutoMapper;
using CSG_ADMINPRO.APLICATION.Interfaces;
using CSG_ADMINPRO.DOMAIN.DTO;
using CSG_ADMINPRO.DOMAIN.Entities;
using Microsoft.AspNetCore.Mvc;
using static Dapper.SqlMapper;

namespace CSG_ADMINPRO.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CitasAPIController : Controller
    {
        private readonly ICitaService _services;
        private readonly ILogger<CitasAPIController> _logger;
        private readonly IMapper _mapper;
        public CitasAPIController(ICitaService citaService, 
                                    ILogger<CitasAPIController> logger,
                                        IMapper mapper)
        {
            _services = citaService;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllCitas()
        {
            try
            {
                var list = await _services.GetAllCitaAsync();

                if(list == null || !list.Any())
                {
                    _logger.LogWarning("No se encontro nada en la lista.");
                    return NotFound("Lista no encontrada.");
                }

                var listViewModel = list.Select(dto => new CitaDTO
                {
                    CitaId = dto.CitaId,
                    CedulaCliente = dto.CedulaCliente,
                    NombreCliente = dto.NombreCliente,
                    FechaCita = dto.FechaCita,
                    FechaCreacionCita = dto.FechaCreacionCita,
                    Motivo = dto.Motivo,
                    Notas = dto.Notas,
                    Ubicacion = dto.Ubicacion,
                    NombreEstado = dto.NombreEstado
                });

                _logger.LogInformation("Se mostraron la lista encontrada.");
                Console.WriteLine($"La cita se genero correctamente.");
                return Ok(listViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError("No hay registros que mostrar.");
                return StatusCode(500, "Error interno del servidor." + ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create(CitaCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogCritical("Datos ingresados no validos.");
                return BadRequest(ModelState);
            }

            try
            {
                //var dataMapper = _mapper.Map<Cita>(dto);
                await _services.CreateCitaAsync(dto);
                _logger.LogInformation("Se creo la cita correctamente.");

                return CreatedAtAction(nameof(Create), new { id = dto.Fecha }, dto );
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Se produjo un error en el servidor.");
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor." + ex.Message);
            }
        }

        [HttpPut]
        [Route("update/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Edit(int id, CitaUpdateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogCritical("Error: al querer actualizar con datos invalidos.");
                return BadRequest(ModelState);
            }

            try
            {
                //var dataMapper = _mapper.Map<Cita>(dto);
                await _services.UpdateCitaAsync(id, dto);
                _logger.LogInformation("Se actualizo correctamente.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogWarning("Error: ocurrio un error al actualizar los datos.");
                return StatusCode(StatusCodes.Status500InternalServerError, " Error interno del servidor: " + ex.Message);
            }
        }

        [HttpGet("search/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetById(int id)
        {
            if(id <= 0)
            {
                _logger.LogCritical("Id no valida o no ha ingreado nada.");
                return BadRequest("ID No valida.");
            }

            var response = await _services.GetByIdAsync(id);
            
            if(response == null)
            {
                _logger.LogCritical("ID no encontrada.");
                return NotFound("ID No encontrada.");
            }

            _logger.LogInformation("ID encontrada.");
            return Ok(response);
        }

        [HttpDelete("delete/{id:int}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            if(id <= 0)
            {
                _logger.LogCritical("Id No Valida.");
                return BadRequest("Id No valida");
            }

            await _services.DeleteCitaAsync(id);
            _logger.LogInformation("Dato eliminado correctamente.");
            return Ok();
        }


    }
}
