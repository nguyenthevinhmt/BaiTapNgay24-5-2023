using System.ComponentModel.DataAnnotations;

namespace ProductManager.Dtos.Product
{
    public class CreateProductDto
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
    }
}
