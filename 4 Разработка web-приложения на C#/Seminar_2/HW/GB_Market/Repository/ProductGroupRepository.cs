using AutoMapper;
using GB_Market.Abstractions;
using GB_Market.DB;
using GB_Market.DTO;
using GB_Market.Models;
using Microsoft.Extensions.Caching.Memory;

namespace GB_Market.Repository
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
        public void AddProductGroup(ProductGroupViewModel productGroupViewModel)
        {
            using (var context = new ProductContext())
            {
                var entityProductGroup = context.ProductGroup.FirstOrDefault(x => x.Name.ToLower().Equals(productGroupViewModel.Name.ToLower()));
                if (entityProductGroup == null)
                {
                    var entity = _mapper.Map<ProductGroup>(productGroupViewModel);
                    context.ProductGroup.Add(entity);
                    //context.ProductGroup.Add(new ProductGroup { Name = productGroupViewModel.Name, Description = productGroupViewModel.Description });
                    context.SaveChanges();
                    _memoryCache.Remove("product_group");
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

        public void DeleteProductGroup(int Id)
        {
            using (var context = new ProductContext())
            {
                var entityProductGroup = context.ProductGroup.FirstOrDefault(x => x.Id.Equals(Id));
                if (entityProductGroup != null)
                {
                    context.ProductGroup.Remove(entityProductGroup);
                    context.SaveChanges();
                    _memoryCache.Remove("product_group");
                }
                else
                {
                    throw new Exception("ProductGroup not exist");
                }
            }
        }

        public void ChangeProductGroupDescription(string name, string description)
        {
            using (var ctx = new ProductContext())
            {
                if (ctx.ProductGroup.FirstOrDefault(x => x.Name.ToLower() == name.ToLower()) != null)
                {
                    var productGroup = ctx.ProductGroup.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
                    productGroup.Description = description;
                    ctx.SaveChanges();
                    _memoryCache.Remove("product_group");
                }
                else
                {
                    throw new Exception("ProductGroup not exist");
                }
            }
        }
    }
}
