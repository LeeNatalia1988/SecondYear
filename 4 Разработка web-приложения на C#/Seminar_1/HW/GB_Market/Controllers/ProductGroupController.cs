using GB_Market.DB;
using GB_Market.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace GB_Market.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Components.Route("[controller]")]
    public class ProductGroupController : ControllerBase
    {
        [HttpPost(template: "add_group")]
        public ActionResult AddGroup(string name, string description)
        {
            try
            {
                using (var ctx = new ProductContext())
                {
                    if (ctx.ProductGroup.FirstOrDefault(x => x.Name.ToLower() == name.ToLower()) != null)
                    {
                        return StatusCode(409);
                    }
                    else
                    {
                        ctx.ProductGroup.Add(new ProductGroup { Name = name, Description = description });
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
        [HttpGet(template: "get_product_group")]
        public ActionResult<IEnumerable<ProductGroup>> GetProductGroup()
        {
            try
            {
                using (var ctx = new ProductContext())
                {
                    var list = ctx.ProductGroup.Select(x => new ProductGroup { Id = x.Id, Name = x.Name, Description = x.Description }).ToList();
                    return list;
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost(template: "delete_product_group")]
        public ActionResult DeleteProductGroup(int Id)
        {
            try
            {
                using (var ctx = new ProductContext())
                {
                    if (ctx.ProductGroup.FirstOrDefault(x => x.Id == Id) == null)
                    {
                        return StatusCode(406);
                    }
                    else
                    {
                        var productGroup = ctx.ProductGroup.Where(x => x.Id == Id).FirstOrDefault();
                        ctx.ProductGroup.Remove(productGroup);
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
        [HttpPost(template: "patch_product_group_description")]
        public ActionResult PatchProductGroupDescription(string name, string description)
        {
            try
            {
                using (var ctx = new ProductContext())
                {
                    if (ctx.ProductGroup.FirstOrDefault(x => x.Name.ToLower() == name.ToLower()) == null)
                    {
                        return StatusCode(406);
                    }
                    else
                    {
                        var productGroup = ctx.ProductGroup.Where(x => x.Name.ToLower() == name.ToLower()).FirstOrDefault();
                        productGroup.Description = description;
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


