using CSG_ADMINPRO.APLICATION.DTOs;
using CSG_ADMINPRO.DOMAIN.Entities;
using CSG_ADMINPRO.UI.Configuration;
using Microsoft.Extensions.Options;
using System.Text.Json;

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

        public async Task CreateClienteAsync(ClienteDTO cliente)
        {
            var endpoint = $"{_apiSettings.Endpoints.Clientes}/create";
            var response = await _httpClient.PostAsJsonAsync(endpoint, cliente);
            Console.WriteLine(endpoint);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();

                // Intenta leer errores específicos si es un JSON
                try
                {
                    var errorObj = JsonSerializer.Deserialize<Dictionary<string, object>>(errorContent);
                    if (errorObj != null && errorObj.ContainsKey("errors"))
                    {
                        var errores = errorObj["errors"].ToString();
                        throw new Exception("Errores de validación: " + errores);
                    }
                }
                catch
                {
                    // Ignora si no es JSON válido
                }

                throw new Exception($"Error al crear al cliente: {response.StatusCode}. Contenido: {errorContent}");
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
