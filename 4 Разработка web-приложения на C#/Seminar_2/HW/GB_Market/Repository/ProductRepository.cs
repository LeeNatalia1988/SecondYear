using AutoMapper;
using Azure.Core;
using GB_Market.Abstractions;
using GB_Market.DB;
using GB_Market.DTO;
using GB_Market.Models;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.Caching.Memory;
using System.Runtime.CompilerServices;
using System.Text;

namespace GB_Market.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMapper _mapper;
        private IMemoryCache _memoryCache;
        public ProductRepository(IMapper mapper, IMemoryCache memoryCache)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
        }
        public void AddProduct(ProductViewModel productViewModel)
        {
            using (var context = new ProductContext())
            {
                var entityProduct = context.Products.FirstOrDefault(x => x.Name.ToLower().Equals(productViewModel.Name.ToLower()));
                if (entityProduct == null)
                {
                    GetCacheCSV();
                    Thread.Sleep(2000);
                    var entity = _mapper.Map<Product>(productViewModel);
                    context.Products.Add(entity);
                    context.SaveChanges();
                    _memoryCache.Remove("products");
                }
                else
                {
                    throw new Exception("Product already exist");
                }
            }
        }


        public IEnumerable<ProductViewModel> GetProducts()
        {
            if (_memoryCache.TryGetValue("products", out List<ProductViewModel> productsCache))
            {
                return productsCache;
            }
            using (var context = new ProductContext())
            {
                var products = context.Products.Select(_mapper.Map<ProductViewModel>).ToList();
                _memoryCache.Set("products", products, TimeSpan.FromMinutes(30));
                return products;
            }
        }

        public void DeleteProduct(int Id)
        {
            using (var context = new ProductContext())
            {
                var entityProduct = context.Products.FirstOrDefault(x => x.Id.Equals(Id));
                if (entityProduct != null)
                {
                    GetCacheCSV();
                    Thread.Sleep(2000);
                    context.Products.Remove(entityProduct);
                    context.SaveChanges();
                    _memoryCache.Remove("products");
                }
                else
                {
                    throw new Exception("Product not exist");
                }
            }
        }

        public void ChangeProductDescription(string name, string description)
        {
            using (var ctx = new ProductContext())
            {
                if (ctx.Products.FirstOrDefault(x => x.Name.ToLower() == name.ToLower()) != null)
                {
                    GetCacheCSV();
                    var product = ctx.Products.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
                    product.Description = description;
                    ctx.SaveChanges();
                    _memoryCache.Remove("products");
                }
                else
                {
                    throw new Exception("Product not exist");
                }
            }
        }

        public string GetProductToString(IEnumerable<Product> products)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var product in products)
            {
                sb.Append("Name: " + product.Name + ";   " + "Description: " + product.Description + "\n");
            }
            return sb.ToString();
        }

        public string GetCacheToString(List<ProductViewModel> productsCache)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var pc in productsCache)
            {
                sb.Append("Name: " + pc.Name + ";   " + "Description: " + pc.Description + "\n");
            }
            return sb.ToString();
        }
        public string GetCacheCSV()
        {
            string content = "";
            string fileName = "";
            if (_memoryCache.TryGetValue("products", out List<ProductViewModel> productsCache))
            {
                content = GetCacheToString(productsCache);
                fileName = "cache" + "(" + DateTime.Now.ToString("dd MMMM yyyy, HH.mm.ss") + ")" + ".csv";
                System.IO.File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "OrderToCSV", fileName), content, System.Text.Encoding.UTF8);
            }
            else
            {
                content = "cache is empty/кэш пуст";
                fileName = "cache" + "(" + DateTime.Now.ToString("dd MMMM yyyy, HH.mm.ss") + ")" + ".csv";
                System.IO.File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "OrderToCSV", fileName), content, System.Text.Encoding.UTF8);
            }
            return fileName;

        }
    }
}
