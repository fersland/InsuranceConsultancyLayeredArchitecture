using AutoMapper;
using CSG_ADMINPRO.APLICATION.DTOs;
using CSG_ADMINPRO.APLICATION.Interfaces;
using CSG_ADMINPRO.DOMAIN.Entities;
using CSG_ADMINPRO.UI.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace CSG_ADMINPRO.UI.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioService _usuarioServices;
        private readonly IEstadoService _estadoServices;
        private readonly IMapper _autoMapper;

        public UsuariosController(IUsuarioService usuarioService,
                                        IEstadoService estadoService,
                                            IMapper autoMapper)
        {
            _usuarioServices = usuarioService;
            _estadoServices = estadoService;
            _autoMapper = autoMapper;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _usuarioServices.GetAllUsuarioAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.EstadoArq = await _estadoServices.GetAllEstadoAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UsuarioPasswordDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Datos Invalidos." });
            }

            try
            {
                var dataDTO = _autoMapper.Map<Usuario>(dto);
                await _usuarioServices.CreateUsuarioAsync(dataDTO);
                TempData["successMessage"] = "Datos registrados correctamente.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View("Error");
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var data = await _usuarioServices.GetByIdUsuarioAsync(id);

            if (data == null)
            {
                return Json(new { success = false, message = "No existe el usuario." });
            }

            var NombreEstados = await _estadoServices.GetAllEstadoAsync();
            ViewBag.EstadoArq = NombreEstados;

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, UsuarioDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Datos Invalidos" });
            }

            try
            {
                var dataDTO = _autoMapper.Map<Usuario>(dto);
                await _usuarioServices.UpdateUsuarioAsync(id, dataDTO);
                TempData["successMessage"] = "Datos actualizados correctamente.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _usuarioServices.DeleteUsuarioAsync(id);
                return Json(new { success = true, message = "Datos eliminado correctamente." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, ex.Message });
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            
            if(id <= 0)
            {
                return Json(new { success = false, message = "ID No Valido" });
            }

            var datos = await _usuarioServices.GetByIdUsuarioAsync(id);

            if (datos == null)
            {
                return Json(new { success = false, message = "Datos no encontrados" });
            }

            var listViewModel = new UsuarioViewModel
            {
                Id = datos.Id,
                NombreUsuario = datos.NombreUsuario,  // Asigna "N/A" si NombreUsuario es null
                CorreoUsuario = datos.CorreoUsuario,  // Asigna "N/A" si CorreoUsuario es null
                FechaCreacion = datos.FechaCrecion
            };

            return View(listViewModel);
        }
    }
}
