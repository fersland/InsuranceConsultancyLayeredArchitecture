using AutoMapper;
using CSG_ADMINPRO.APLICATION.DTOs;
using CSG_ADMINPRO.APLICATION.Interfaces;
using CSG_ADMINPRO.DOMAIN.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CSG_ADMINPRO.API.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class ClientesAPIController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _autoMapper;
        private readonly ILogger<ClientesAPIController> _logger;

        public ClientesAPIController(IClienteService clienteService,
                                        IMapper autoMapper,
                                        ILogger<ClientesAPIController> logger)
        {
            _clienteService = clienteService;
            _autoMapper = autoMapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("/list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllCliente()
        {
            try
            {
                var list = await _clienteService.GetAllClientesAsync();

                if(list == null)
                {
                    return NotFound("Lista no encontrada.");
                }

                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor." + ex.Message);
            }
        }

        [HttpGet]
        [Route("/search/{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByIdCliente(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("ID no valida");
                }

                var result = await _clienteService.GetClienteByIdAsync(id);

                if (result == null)
                {
                    return NotFound("Id no encontrada");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor. " + ex.Message);
            }
        }

        [HttpPost("create")]
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

                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear cliente.");
                return StatusCode(500, new { success = false, message = ex.Message });
            }
        }


        [HttpPut]
        [Route("/update/{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Cliente dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var clienteExistente = await _clienteService.GetClienteByIdAsync(id);

                if(clienteExistente == null)
                {
                    return NotFound("Cliente no encontrado.");
                }

                var clienteActualizado = _autoMapper.Map<Cliente>(dto);

                if(clienteActualizado is null)
                {
                    return NotFound("Cliente no encontrado.");
                }

                clienteActualizado.Id = id;

                await _clienteService.UpdateClienteAsync(id, clienteActualizado);
                return Ok("Cliente actualizado correctamente.");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        [Route("/delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if(id <= 0)
                {
                    return BadRequest("ID no valida");
                }

                var result = await _clienteService.GetClienteByIdAsync(id);

                if(result == null) {
                    return NotFound("ID no encontrada");
                }

                await _clienteService.DeleteClienteAsync(id);
                return Ok("El cliente fue elimiando correctamente.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno del servidor" + ex.Message);
            }
        }
    }
}
