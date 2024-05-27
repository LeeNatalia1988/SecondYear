using GB_Market.Abstractions;
using GB_Market.DB;
using GB_Market.DTO;
using GB_Market.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace GB_Market.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpPost(template: "add_product")]
        public ActionResult AddProduct(ProductViewModel productViewModel)
        {
            try
            {
                _repository.AddProduct(productViewModel);
                return Ok();
            }
            catch
            {
                return StatusCode(409);
            }
        }

        [HttpGet(template: "get_products")]
        public ActionResult<IEnumerable<ProductViewModel>> GetProducts()
        {
            return Ok(_repository.GetProducts());
        }

        [HttpDelete(template: "delete_product")]
        public ActionResult DeleteProduct(int Id)
        {
            _repository.DeleteProduct(Id);
            return Ok();
        }

        [HttpPatch(template: "change_product_description")]
        public ActionResult ChangeProductDescription(string name, string description)
        {
            _repository.ChangeProductDescription(name, description);
            return Ok();
        }

        [HttpGet(template: "get_url_products_to_csv")]
        public ActionResult<string> GetUrlProductsToCSV()
        {
            var content = "";
            using (var ctx = new ProductContext())
            {
                var products = ctx.Products.Select(p => new Product { Name = p.Name, Description = p.Description}).ToList();
                content = _repository.GetProductToString(products);
            }
            string fileName = "";
            fileName = "products" + "(" + DateTime.Now.ToString("dd MMMM yyyy, HH.mm.ss") + ")" + ".csv";
            System.IO.File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "OrderToCSV", fileName), content, System.Text.Encoding.UTF8);
            return "https://" + Request.Host.ToString() + "/OrderToCSV/" + fileName;
        }

        [HttpGet(template: "get_url_cache_to_csv")]
        public ActionResult<string> GetUrlCacheToCSV()
        {
            return "https://" + Request.Host.ToString() + "/OrderToCSV/" + _repository.GetCacheCSV();
        }
    }
}
