namespace CSG_ADMINPRO.UI.Configuration
{
    public class ApiSettings
    {
        public string BaseUrl { get; set; } = string.Empty;
        public ApiEndpoints Endpoints { get; set; } = new ApiEndpoints();
    }
}
