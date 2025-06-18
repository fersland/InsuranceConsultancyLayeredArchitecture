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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClienteDTO dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["errorMessage"] = "Los datos ingresados son invalidos.";
            }
            try
            {
                var dataDto = _mapper.Map<ClienteDTO>(dto);
                await _service.CreateClienteAsync(dataDto);
                TempData["successMessage"] = "Datos registrados correctamente.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var result = await _service.BuscarClienteIdAsync(id);
                return View(result);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Datos invalidos" });
            }

            try
            {
                await _service.UpdateClienteAsync(id, cliente);
                TempData["successMessage"] = "Datos actualizados correctamente.";
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
                await _service.DeleteClienteAsync(id);
                return Json(new { success = true, message = "Dato eliminados correctamente." });
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
