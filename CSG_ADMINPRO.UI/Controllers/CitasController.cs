using CSG_ADMINPRO.APLICATION.Interfaces;
using CSG_ADMINPRO.DOMAIN.DTO;
using CSG_ADMINPRO.DOMAIN.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace CSG_ADMINPRO.UI.Controllers
{
    public class CitasController : Controller
    {
        private readonly HttpClient _httpclient;
        private readonly ILogger<CitasController> _logger;
        private readonly IClienteService _clienteService;

        public CitasController(IHttpClientFactory httpClientFactory, 
                                    ILogger<CitasController> logger, 
                                        IClienteService clienteService)
        {
            _httpclient = httpClientFactory.CreateClient();
            _httpclient.BaseAddress = new Uri("https://localhost:7261/api/CitasAPI/");
            _logger = logger;
            _clienteService = clienteService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var response = await _httpclient.GetAsync("list");
                _logger.LogInformation($"Requested URL: {_httpclient.BaseAddress}list");
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var citas = JsonSerializer.Deserialize<List<CitaDTO>>(responseBody, options);

                return View(citas);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener citas: {ex.Message}");
                TempData["errorMessage"] = ex.Message;
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var clientes = await _clienteService.GetAllClientesAsync();

            ViewBag.Clientes = clientes;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CitaCreateDTO citaCreateDTO)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Los datos son invalidos."});
            }

            try
            {
                var postJson = new StringContent(JsonSerializer.Serialize(citaCreateDTO), Encoding.UTF8, "application/json");

                var response = await _httpclient.PostAsync("create", postJson);
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Datos registrados correctamente.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error: no se realizo el registro");
                    return View(citaCreateDTO);
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id){
            if(id <= 0)
            {
                return Json(new { success = false, message = "La ID no es valida." });
            }

            try
            {
                var clientes = await _clienteService.GetAllClientesAsync();
                ViewBag.Clientes = clientes;

                var response = await _httpclient.GetAsync($"search/{id}");
                response.EnsureSuccessStatusCode();

                var responseBody = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var cita = JsonSerializer.Deserialize<CitaCreateDTO>(responseBody, options);
                return View(cita);
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, CitaCreateDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

            var clientes = await _clienteService.GetAllClientesAsync();
            ViewBag.Clientes = clientes;

            try
            {
                var putJson = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
                var response = await _httpclient.PutAsync($"update/{id}", putJson);
                if (response.IsSuccessStatusCode)
                {
                    TempData["successMessage"] = "Datos actualizados correctamente.";
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Error: no se realizo la actualizacion");
                    return View(dto);
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _httpclient.DeleteAsync($"delete/{id}");

                if (response.IsSuccessStatusCode)
                {
                    return Json(new { success = true, message = "Datos eliminados correctamente." });
                }
                else
                {
                    return Json(new { success = false, message = "Ocurrio un error." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

    }
}
