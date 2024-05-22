using GB_Market.DB;
using GB_Market.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace GB_Market.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Components.Route("[controller]")]
    public class ProductController : ControllerBase
    {
        [HttpPost(template: "add_product")]
        public ActionResult AddProduct(string name, string description)
        {
            try
            {
                using (var ctx = new ProductContext())
                {
                    if (ctx.Products.FirstOrDefault(x => x.Name.ToLower() == name.ToLower()) != null)
                    {
                        return StatusCode(409);
                    }
                    else
                    {
                        ctx.Products.Add(new Product { Name = name, Description = description});
                        ctx.SaveChanges();
                    }
                }

                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpGet(template: "get_products")]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            try
            {
                using (var ctx = new ProductContext())
                {
                    var list = ctx.Products.Select(x => new Product { Id = x.Id, Name = x.Name, Description = x.Description }).ToList();
                    return list;
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete(template: "delete_product")]
        public ActionResult DeleteProduct(int Id)
        {
            try
            {
                using (var ctx = new ProductContext())
                {
                    if (ctx.Products.FirstOrDefault(x => x.Id == Id) == null)
                    {
                        return StatusCode(406);
                    }
                    else
                    {
                        var product = ctx.Products.Where(x => x.Id == Id).FirstOrDefault();
                        ctx.Products.Remove(product);
                        ctx.SaveChanges();
                    }
                }

                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPatch(template: "change_product_description")]
        public ActionResult ChangeProductDescription(string name, string description)
        {
            try
            {
                using (var ctx = new ProductContext())
                {
                    if (ctx.Products.FirstOrDefault(x => x.Name.ToLower() == name.ToLower()) == null)
                    {
                        return StatusCode(406);
                    }
                    else
                    {
                        var product = ctx.Products.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
                        product.Description = description;
                        ctx.SaveChanges();
                    }
                }

                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
