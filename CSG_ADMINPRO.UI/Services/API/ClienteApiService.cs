using CSG_ADMINPRO.APLICATION.DTOs;
using CSG_ADMINPRO.DOMAIN.Entities;
using CSG_ADMINPRO.UI.Configuration;
using Microsoft.Extensions.Options;
using System.Text.Json;
using Newtonsoft.Json;


namespace CSG_ADMINPRO.UI.Services.API
{
    public class ClienteApiService : IClienteApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiSettings _apiSettings;

        public ClienteApiService(
                    IHttpClientFactory httpClientFactory,
                    IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
            _apiSettings = apiSettings.Value;
        }

        public async Task<IEnumerable<Cliente>> ObtenerClienteAsync()
        {
            var endpoint = $"{_apiSettings.Endpoints.Clientes}/list";
            var response = await _httpClient.GetAsync(endpoint);
            if (!response.IsSuccessStatusCode)
            {
                return Enumerable.Empty<Cliente>();
            }

            var data = await response.Content.ReadFromJsonAsync<List<Cliente>>();
            return data ?? new List<Cliente>();
        }

        public async Task<Cliente?> BuscarClienteIdAsync(int id)
        {
            var endpoint = $"{_apiSettings.Endpoints.Clientes}/search/{id}";
            var response = await _httpClient.GetAsync(endpoint);

            if(!response.IsSuccessStatusCode || response.Content == null)
            {
                return null;
            }

            var data = await response.Content.ReadFromJsonAsync<Cliente>();
            return data;
        }

        public async Task<(bool Success, string Message)> CreateClienteAsync(ClienteDTO cliente)
        {
            var endpoint = "https://localhost:7261/api/cliente/create";
            var response = await _httpClient.PostAsJsonAsync(endpoint, cliente);

            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return (true, "Cliente creado correctamente.");
            }
            else
            {
                try
                {
                    var error = JsonConvert.DeserializeObject<dynamic>(content);

                    // Manejar errores del tipo: { success: false, message: "...", errors: {...} }
                    if (error?.message != null)
                        return (false, (string)error.message);

                    if (error?.errors != null)
                    {
                        // Concatenar errores de ModelState
                        var errorList = new List<string>();
                        foreach (var item in error.errors)
                        {
                            foreach (var e in item.Value)
                            {
                                errorList.Add((string)e);
                            }
                        }
                        return (false, string.Join(" ", errorList));
                    }

                    return (false, "Error desconocido al crear el cliente.");
                }
                catch
                {
                    return (false, "Error inesperado al interpretar la respuesta del servidor.");
                }
            }
        }


        public async Task UpdateClienteAsync(int id, Cliente cliente)
        {
            var endpoint = $"{_apiSettings.Endpoints.Clientes}/update/" + id;
            var response = await _httpClient.PutAsJsonAsync(endpoint, cliente);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al actualizar al cliente: {response.StatusCode}");
            }
        }

        public async Task DeleteClienteAsync(int id)
        {
            var endpoint = $"{_apiSettings.Endpoints.Clientes}/delete/" + id;
            var response = await _httpClient.DeleteAsync(endpoint);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error al eliminar al cliente: {response.StatusCode}");
            }
        }
    }
}
