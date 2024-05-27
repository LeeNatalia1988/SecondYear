using MyMarket.Abstractions;
using MyMarket.DB;
using MyMarket.DTO;
using MyMarket.Models;

using Microsoft.AspNetCore.Mvc;

namespace MyMarket.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public ActionResult<IEnumerable<ProductGroupViewModel>> GetProductGroup()
        {
            return Ok(_repository.GetProductGroup());
        }

        [HttpPost(template: "delete_product_group")]
        public ActionResult DeleteProductGroup(int Id)
        {
            _repository.DeleteProductGroup(Id);
            return Ok();
        }
        [HttpPost(template: "change_product_group_description")]
        public ActionResult ChangeProductGroupDescription(string name, string description)
        {
            _repository.ChangeProductGroupDescription(name, description);
            return Ok();
        }
    }
}


