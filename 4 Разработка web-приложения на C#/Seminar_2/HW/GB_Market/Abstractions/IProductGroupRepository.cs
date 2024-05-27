using GB_Market.DTO;
using GB_Market.Models;
using Microsoft.Extensions.Caching.Memory;

namespace GB_Market.Abstractions
{
    public interface IProductGroupRepository
    {
        public void AddProductGroup(ProductGroupViewModel productGroupViewModel);
        public IEnumerable<ProductGroupViewModel> GetProductGroup();

        public void DeleteProductGroup(int Id);

        public void ChangeProductGroupDescription(string name, string description);
    }
}
