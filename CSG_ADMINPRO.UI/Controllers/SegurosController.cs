using CSG_ADMINPRO.DOMAIN.Entities;
using CSG_ADMINPRO.APLICATION.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace CSG_ADMINPRO.UI.Controllers
{
    public class SegurosController : Controller
    {
        private readonly ISeguroService _services;
        private readonly ILogger<SegurosController> _logger;

        public SegurosController(ISeguroService seguroService, ILogger<SegurosController> logger)
        {
            _services = seguroService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var list = await _services.GetAllSegurosAsync();
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
        public async Task<IActionResult> Create(Seguro seguro)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Datos invalidos.";
                return View(seguro);
            }

            if(seguro.Codigo.Contains("<script>") || seguro.Codigo.Contains("<") || seguro.Codigo.Contains(">"))
            {
                ModelState.AddModelError(string.Empty, "Lo ingresado contiene caracteres no permitidos.");
                return View(seguro);
            }
            if (seguro.NombreSeguro.Contains("<script>") || seguro.NombreSeguro.Contains("<") || seguro.NombreSeguro.Contains(">"))
            {
                ModelState.AddModelError(string.Empty, "Lo ingresado contiene caracteres no permitidos.");
                return View(seguro);
            }

            if (seguro.Asegurada.Contains("<script>") || seguro.Asegurada.Contains("<") || seguro.Asegurada.Contains(">"))
            {
                ModelState.AddModelError(string.Empty, "Lo ingresado contiene caracteres no permitidos.");
                return View(seguro);
            }

            if (seguro.Prima.Contains("<script>") || seguro.Prima.Contains("<") || seguro.Prima.Contains(">"))
            {
                ModelState.AddModelError(string.Empty, "Lo ingresado contiene caracteres no permitidos.");
                return View(seguro);
            }

            try
            {
                await _services.CreateSeguroAsync(seguro);
                TempData["successMessage"] = "Datos registrados correctamente.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var result = await _services.GetSeguroByIdAsync(id);
                return View(result);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View("Error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Seguro seguro)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Datos Invalidos" });
            }

            try
            {
                await _services.UpdateSeguroAsync(id, seguro);
                TempData["successMessage"] = "Datos actualizados correctamente";
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
                await _services.DeleteSeguroAsync(id);
                return Json(new { success = true, message = "Datos eliminados correctamente" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message});
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var result = await _services.GetSeguroByIdAsync(id);
                return View(result);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return View("Error");
            }
        }
    }
}
