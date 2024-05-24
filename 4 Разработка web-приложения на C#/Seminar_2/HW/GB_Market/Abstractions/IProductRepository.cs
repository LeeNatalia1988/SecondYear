using GB_Market.DTO;
using GB_Market.Models;
using Microsoft.Extensions.Caching.Memory;

namespace GB_Market.Abstractions
{
    public interface IProductRepository
    {
        public void AddProduct(ProductViewModel productViewModel);
        public IEnumerable<ProductViewModel> GetProducts();

        public void DeleteProduct(int Id);

        public void ChangeProductDescription(string name, string description);

        public string GetProductToString(IEnumerable<Product> products);

        public string GetCacheToString(List<ProductViewModel> productsCache);
        public string GetCacheCSV();
    }
}
