namespace HepsiYemekApi.WebApi.Models
{
    public class ProductModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryModel Category { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
    }
}