using Autofac.Core;
using MyMarket.Abstractions;
using MyMarket.DTO;
using MyMarket.Repository;

namespace MyMarket.GraphQLServices.Mutation
{
    public class Mutation
    {
        private readonly IProductGroupRepository _productGroupRepository;
        private readonly IProductRepository _productRepository;
        private readonly IStorageRepository _storageRepository;
        public Mutation(IProductGroupRepository productGroupRepository, IProductRepository productRepository, IStorageRepository storageRepository)
        {
            _productGroupRepository = productGroupRepository;
            _productRepository = productRepository;
            _storageRepository = storageRepository;
        }

        public int AddProductGroup(ProductGroupViewModel productGroupViewModel)=> _productGroupRepository.AddProductGroup(productGroupViewModel);

        public int AddProduct(ProductViewModel productViewModel) => _productRepository.AddProduct(productViewModel);

        public int AddStorage(StorageViewModel storageViewModel) => _storageRepository.AddStorage(storageViewModel);

    }
}
