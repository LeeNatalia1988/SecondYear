using GB_Market.Abstractions;
using GB_Market.DB;
using GB_Market.DTO;
using GB_Market.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace GB_Market.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Components.Route("[controller]")]
    public class ProductGroupController : ControllerBase
    {
        private readonly IProductGroupRepository _repository;
        public ProductGroupController(IProductGroupRepository repository)
        {
            _repository = repository;
        }

        [HttpPost(template: "add_group")]
        public ActionResult AddProductGroup(ProductGroupViewModel productGroupViewModel)
        {
            try
            {
                _repository.AddProductGroup(productGroupViewModel);
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
            return Ok(_repository.GetProductGroup());
        }

        [HttpDelete(template: "delete_product_group")]
        public ActionResult DeleteProductGroup(int Id)
        {
            _repository.DeleteProductGroup(Id);
            return Ok();
        }
        [HttpPatch(template: "change_product_group_description")]
        public ActionResult ChangeProductGroupDescription(string name, string description)
        {
            _repository.ChangeProductGroupDescription(name, description);
            return Ok();
        }
    }
}


