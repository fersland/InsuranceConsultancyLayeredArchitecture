using CSG_ADMINPRO.DOMAIN.Entities;
using CSG_ADMINPRO.APLICATION.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace CSG_ADMINPRO.UI.Controllers
{
    public class SegurosController : Controller
    {
        private readonly ISeguroService _services;

        public SegurosController(ISeguroService seguroService)
        {
            _services = seguroService;    
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
                return RedirectToAction("Index");
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
                return Json(new { success = true, message = "Datos elimiandos correctamente" });
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
