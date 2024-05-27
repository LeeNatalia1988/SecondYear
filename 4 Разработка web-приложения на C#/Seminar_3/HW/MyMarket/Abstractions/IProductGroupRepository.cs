using MyMarket.DTO;

namespace MyMarket.Abstractions
{
    public interface IProductGroupRepository
    {
        public int AddProductGroup(ProductGroupViewModel productGroupViewModel);
        public IEnumerable<ProductGroupViewModel> GetProductGroup();

        public int DeleteProductGroup(int Id);

        public int ChangeProductGroupDescription(string name, string description);
    }
}
