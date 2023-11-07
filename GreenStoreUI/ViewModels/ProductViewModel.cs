using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EShop.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public decimal? Price { get; set; }

        [DisplayName("Category")]
        public int CategoryId { get; set; }

        public int? Quntity { get; set; }

        public List<string>? PhotosLink { get; set; }

        [DisplayName("Photos"),MaxLength(3, ErrorMessage = "A product can't contain more than 3 Pictures!")]
        public List<IFormFile>? PhotoFiles { get; set; }
    }
}
