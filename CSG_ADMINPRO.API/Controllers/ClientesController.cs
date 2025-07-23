using AutoMapper;
using CSG_ADMINPRO.APLICATION.DTOs;
using CSG_ADMINPRO.APLICATION.Interfaces;
using CSG_ADMINPRO.DOMAIN.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace CSG_ADMINPRO.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _autoMapper;
        private readonly ILogger<ClientesController> _logger;

        public ClientesController(IClienteService clienteService,
                                        IMapper autoMapper,
                                        ILogger<ClientesController> logger)
        {
            _clienteService = clienteService;
            _autoMapper = autoMapper;
            _logger = logger;
        }

        [HttpGet("list")]
        [ProducesResponseType(typeof(IEnumerable<Cliente>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllCliente()
        {
            try
            {
                var list = await _clienteService.GetAllClientesAsync();

                if(list == null || !list.Any())
                {
                    _logger.LogWarning("No se encontraron resultados.");
                    return NotFound("Lista no encontrada.");
                }

                _logger.LogInformation("Se listaron clientes correctmaente.");
                return Ok(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error interno al listar clientes.");

                var problem = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Error interno del servidor.",
                    Detail = ex.Message
                };

                return StatusCode(StatusCodes.Status500InternalServerError, problem);
            }
        }

        [HttpGet("search/{id:int}")]
        [ProducesResponseType(typeof(Cliente), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdCliente(int id)
        {
            try
            {
                if (id <= 0)
                {
                    _logger.LogCritical("No se encontro resultados con la ID ingresada.");
                    return BadRequest("ID no valida");
                }

                var result = await _clienteService.GetClienteByIdAsync(id);

                if (result == null)
                {
                    _logger.LogCritical("No se encontro nada relacionado con la ID inrgesada.");
                    return NotFound("Id no encontrada");
                }

                _logger.LogInformation("Se mostraron resultados correctamente.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en el servidor");

                var problem = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Error Interno del Servidor",
                    Detail = ex.Message
                };

                return StatusCode(StatusCodes.Status500InternalServerError, problem);
            }
        }

        [HttpPost("create")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] ClienteDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .ToDictionary(
                            kvp => kvp.Key,
                            kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                        );

                    return BadRequest(new { success = false, errors });
                }

                var entity = _autoMapper.Map<Cliente>(dto);
                await _clienteService.CreateClienteAsync(entity);

                return Ok(new
                {
                    success = true,
                    message = "Cliente creado correctamente."
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear cliente.");

                var problem = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Error Interno del Servidor",
                    Detail = ex.Message
                };

                return StatusCode(StatusCodes.Status500InternalServerError, problem);
            }
        }


        [HttpPut("update/{id:int}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] Cliente dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .ToDictionary(
                            kvp => kvp.Key,
                            kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                    );

                    return BadRequest(new
                    {
                        succes = false,
                        message = "Errores de validacion.",
                        errors
                    });
                }

                var clienteExistente = await _clienteService.GetClienteByIdAsync(id);

                if (clienteExistente == null)
                {
                    return NotFound("Cliente no encontrado.");
                }

                var clienteActualizado = _autoMapper.Map<Cliente>(dto);
                clienteActualizado.Id = id;

                await _clienteService.UpdateClienteAsync(id, clienteActualizado);
                return Ok(new
                {
                    success = true,
                    message = "Cliente actualizado correctamente."
                });                
            }
            catch (Exception ex)
            {
                var problem = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Error interno del servidor",
                    Detail = ex.Message
                };

                return StatusCode(StatusCodes.Status500InternalServerError, problem);
            }
        }

        [HttpDelete("delete/{id:int}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if(id <= 0)
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "ID no valido."
                    });
                }

                var result = await _clienteService.GetClienteByIdAsync(id);

                if(result == null) {
                    return NotFound(new
                    {
                        success = false,
                        message = "Cliente no encontrado."
                    });
                }

                await _clienteService.DeleteClienteAsync(id);
                return Ok(new
                {
                    success = true,
                    message = "Cliente eliminado correctamente."
                });
            }
            catch (Exception ex)
            {
                var problem = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "Error interno del servidor",
                    Detail = ex.Message
                };

                return StatusCode(StatusCodes.Status500InternalServerError, problem);
            }
        }
    }
}
