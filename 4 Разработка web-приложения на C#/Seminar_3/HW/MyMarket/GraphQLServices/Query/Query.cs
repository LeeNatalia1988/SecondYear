using MyMarket.Abstractions;
using MyMarket.DTO;
using MyMarket.Repository;
using HotChocolate;

namespace MyMarket.GraphQLServices.Query
{
    public class Query
    {
        public IEnumerable<ProductViewModel> GetProducts([Service] ProductRepository productRepository) => productRepository.GetProducts();
        public IEnumerable<ProductGroupViewModel> GetProductGroup([Service] ProductGroupRepository productGroupRepository) => productGroupRepository.GetProductGroup();
        public IEnumerable<StorageViewModel> GetStorages([Service] StorageRepository StorageRepository) => StorageRepository.GetStorages();
    }
}
