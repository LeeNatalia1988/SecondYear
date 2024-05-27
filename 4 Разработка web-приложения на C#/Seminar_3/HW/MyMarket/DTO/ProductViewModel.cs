using MyMarket.Models;

namespace MyMarket.DTO
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ProductGroupId { get; set; }
    }
}
