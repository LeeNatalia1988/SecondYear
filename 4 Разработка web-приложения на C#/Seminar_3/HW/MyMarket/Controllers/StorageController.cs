using MyMarket.Abstractions;
using MyMarket.DB;
using MyMarket.DTO;
using MyMarket.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyMarket.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StorageController : ControllerBase
    {
        private readonly IStorageRepository _repository;

        public StorageController(IStorageRepository repository)
        {
            _repository = repository;
        }

        [HttpPost(template: "add_storage")]
        public ActionResult AddStorage(StorageViewModel storageViewModel)
        {
            try
            {
                _repository.AddStorage(storageViewModel);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpGet(template: "get_storages")]
        public ActionResult<IEnumerable<StorageViewModel>> GetStorages()
        {
            return Ok(_repository.GetStorages());
        }

        [HttpPost(template: "delete_storage")]
        public ActionResult DeleteStorage(int Id)
        {
            _repository.DeleteStorage(Id);
            return Ok();
        }
    }
}