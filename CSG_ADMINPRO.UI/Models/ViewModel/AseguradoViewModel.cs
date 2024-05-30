namespace CSG_ADMINPRO.UI.Models.ViewModel
{
    public class AseguradoViewModel
    {
        public int Id { get; set; }
        public string Cedula { get; set; } = null!;
        public string NombreCliente { get; set; } = null!;
        public string Codigo { get; set; } = null!;
        public string NombreSeguro { get; set; } = null!;
        public decimal? Asegurada { get; set; }
        public decimal? Prima { get; set; }
    }
}
