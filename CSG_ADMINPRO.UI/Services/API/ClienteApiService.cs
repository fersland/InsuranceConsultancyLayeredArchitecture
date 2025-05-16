using CSG_ADMINPRO.DOMAIN.Entities;

namespace CSG_ADMINPRO.UI.Services.API
{
    public class ClienteApiService : IClienteApiService
    {
        private readonly HttpClient _httpClient;

        public ClienteApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("ApiClient");
        }

        public async Task<IEnumerable<Cliente>> ObtenerClienteAsync()
        {
            var response = await _httpClient.GetAsync("/list");
            if (!response.IsSuccessStatusCode)
            {
                return Enumerable.Empty<Cliente>();
            }

            var data = await response.Content.ReadFromJsonAsync<List<Cliente>>();
            return data ?? new List<Cliente>();
        }
    }
}
