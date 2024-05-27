using MyMarket.DTO;
using MyMarket.Models;
using Microsoft.Extensions.Caching.Memory;

namespace MyMarket.Abstractions
{
    public interface IProductRepository
    {
        public int AddProduct(ProductViewModel productViewModel);
        public IEnumerable<ProductViewModel> GetProducts();

        public int DeleteProduct(int Id);

        public int ChangeProductDescription(string name, string description);

        public string GetProductToString(IEnumerable<Product> products);

        public string GetCacheToString(List<ProductViewModel> productsCache);
        public string GetCacheCSV();
    }
}
