namespace CalculateApp.Components.Pages.Catalog
{
    public class CatalogFilterModel
    {
        public string? ProductName { get; set; }
        public int? CategoryId { get; set; }
        public decimal? PriceMin { get; set; }
        public decimal? PriceMax { get; set; }
    }
}
