using AutoMapper;
using MyMarket.Abstractions;
using MyMarket.DB;
using MyMarket.DTO;
using MyMarket.Models;
using Microsoft.Extensions.Caching.Memory;

namespace MyMarket.Repository
{
    public class ProductGroupRepository : IProductGroupRepository
    {
        private readonly IMapper _mapper;
        private IMemoryCache _memoryCache;

        public ProductGroupRepository(IMapper mapper, IMemoryCache memoryCache)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
        }
        public int AddProductGroup(ProductGroupViewModel productGroupViewModel)
        {
            using (var context = new ProductContext())
            {
                var entityProductGroup = context.ProductGroup.FirstOrDefault(x => x.Name.ToLower().Equals(productGroupViewModel.Name.ToLower()));
                if (entityProductGroup == null)
                {
                    var entity = _mapper.Map<ProductGroup>(productGroupViewModel);
                    context.ProductGroup.Add(entity);
                    context.SaveChanges();
                    _memoryCache.Remove("product_group");
                    return entity.Id;
                }
                else
                {
                    throw new Exception("ProductGroup already exist");
                }
            }
        }

        public IEnumerable<ProductGroupViewModel> GetProductGroup()
        {
            if (_memoryCache.TryGetValue("product_group", out List<ProductGroupViewModel> productGroupCache))
            {
                return productGroupCache;
            }
            using (var context = new ProductContext())
            {
                var productGroup = context.ProductGroup.Select(_mapper.Map<ProductGroupViewModel>).ToList();
                _memoryCache.Set("product_group", productGroup, TimeSpan.FromMinutes(30));
                return productGroup;
            }
        }

        public int DeleteProductGroup(int Id)
        {
            using (var context = new ProductContext())
            {
                var entityProductGroup = context.ProductGroup.FirstOrDefault(x => x.Id.Equals(Id));
                if (entityProductGroup != null)
                {
                    context.ProductGroup.Remove(entityProductGroup);
                    context.SaveChanges();
                    _memoryCache.Remove("product_group");
                    return entityProductGroup.Id;
                }
                else
                {
                    throw new Exception("ProductGroup not exist");
                }
            }
        }

        public int ChangeProductGroupDescription(string name, string description)
        {
            using (var ctx = new ProductContext())
            {
                if (ctx.ProductGroup.FirstOrDefault(x => x.Name.ToLower() == name.ToLower()) != null)
                {
                    var productGroup = ctx.ProductGroup.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
                    productGroup.Description = description;
                    ctx.SaveChanges();
                    _memoryCache.Remove("product_group");
                    return productGroup.Id;
                }
                else
                {
                    throw new Exception("ProductGroup not exist");
                }
            }
        }
    }
}
