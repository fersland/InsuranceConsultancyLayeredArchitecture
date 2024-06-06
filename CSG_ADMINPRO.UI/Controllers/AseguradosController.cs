using AutoMapper;
using CSG_ADMINPRO.APLICATION.Interfaces;
using CSG_ADMINPRO.DOMAIN.Entities;
using CSG_ADMINPRO.UI.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices.JavaScript;

namespace CSG_ADMINPRO.UI.Controllers
{
    public class AseguradosController : Controller
    {
        private readonly IAseguradoService _serviceAsegurado;
        private readonly IClienteService _serviceCliente;
        private readonly ISeguroService _serviceSeguro;
        private readonly IMapper _autoMapper;

        public AseguradosController(IAseguradoService service, 
                                        ISeguroService serviceSeguro,
                                            IClienteService clienteService,
                                                IMapper mapper)
        {
            _serviceAsegurado = service;
            _serviceSeguro = serviceSeguro;
            _serviceCliente = clienteService;
            _autoMapper = mapper;
        }

        public async Task<ActionResult> Index()
        {
            try
            {
                var aseguradosDto = await _serviceAsegurado.GetAllAseguradosAsync();
                var listViewModel = aseguradosDto.Select(dto => new AseguradoViewModel
                {
                    Id = dto.Id,
                    Cedula = dto.Cedula,
                    NombreCliente = dto.NombreCliente,
                    Codigo = dto.Codigo,
                    NombreSeguro = dto.NombreSeguro,
                    Asegurada = dto.Asegurada,
                    Prima = dto.Prima
                });
                return View(listViewModel);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View("Error");
            }
        }

        public async Task<IActionResult> Create()
        {
            var clientes = await _serviceCliente.GetAllClientesAsync();
            var seguros = await _serviceSeguro.GetAllSegurosAsync();

            ViewBag.Clientes = clientes;
            ViewBag.Seguros = seguros;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AseguradoCreateViewModel dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Datos invalidos.";
                return RedirectToAction("Index");
            }

            try
            {
                var dataEntity = _autoMapper.Map<Asegurado>(dto);
                await _serviceAsegurado.CreateAseguradoAsync(dataEntity);
                TempData["successMessage"] = "Datos registrados correctamente.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var asegurado = await _serviceAsegurado.GetByIdAseguradoAsync(id);

            if(asegurado == null)
            {
                TempData["ErrorMessage"] = "Datos no encontrados";
            }

            var clientes = await _serviceCliente.GetAllClientesAsync();
            var seguros = await _serviceSeguro.GetAllSegurosAsync();

            ViewBag.Clientes = clientes;
            ViewBag.Seguros = seguros;

            return View(asegurado);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AseguradoCreateViewModel dto)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Datos invalidos";
            }

            try
            {
                var dataEntity = _autoMapper.Map<Asegurado>(dto);
                await _serviceAsegurado.UpdateAseguradoAsync(id, dataEntity);
                TempData["successMessage"] = "Datos actualizados correctamente.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _serviceAsegurado.DeleteAseguradoAsync(id);
                return Json(new { success = true, message = "Datos eliminados correctamente si señor." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
