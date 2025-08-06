using CSG_ADMINPRO.DOMAIN.Entities;
using CSG_ADMINPRO.APLICATION.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CSG_ADMINPRO.UI.Services.API;
using CSG_ADMINPRO.APLICATION.DTOs;
using AutoMapper;

namespace CSG_ADMINPRO.UI.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClienteApiService _service;
        private readonly IMapper _mapper;

        public ClientesController(IClienteApiService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var list = await _service.ObtenerClienteAsync();
                TempData.Keep();
                return View(list);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View("Error");
            }            
        }

        public IActionResult Create()
        {
            return View(new ClienteDTO());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClienteDTO dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["errorMessage"] = "Los datos ingresados son invalidos.";
                return View(dto);
            }

            try
            {
                var dataDto = _mapper.Map<ClienteDTO>(dto);
                var (success, message) = await _service.CreateClienteAsync(dataDto);

                if (success)
                {
                    TempData["successMessage"] = message;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["errorMessage"] = message;
                    return View(dto);
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View(dto);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var result = await _service.BuscarClienteIdAsync(id);
                var clienteDto = _mapper.Map<ClienteDTO>(result);
                return View(clienteDto);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ClienteDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            try
            {
                var dataDto = _mapper.Map<ClienteDTO>(dto);
                var (success, message) = await _service.UpdateClienteAsync(dto.Id, dataDto);
                if (success)
                {
                    TempData["successMessage"] = message;
                }
                else
                {
                    TempData["errorMessage"] = message;
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var (success, message) = await _service.DeleteClienteAsync(id);
                return Json(new { success, message });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _service.BuscarClienteIdAsync(id);
            return View(result);
        }
    }
}
