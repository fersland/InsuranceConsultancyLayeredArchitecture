using AutoMapper;
using CSG_ADMINPRO.APLICATION.DTOs;
using CSG_ADMINPRO.APLICATION.Interfaces;
using CSG_ADMINPRO.DOMAIN.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CSG_ADMINPRO.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        [Route("BuscarCLiente/{id:int}")]
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

        [HttpPost]
        public async Task<IActionResult> Create(ClienteDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var data = _autoMapper.Map<Cliente>(dto);
                await _clienteService.CreateClienteAsync(data);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear un cliente.");
                return StatusCode(500, "Error interno del servidor. " + ex.Message);
            }
        }

        [HttpDelete]
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
