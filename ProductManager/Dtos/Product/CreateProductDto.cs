using System.ComponentModel.DataAnnotations;

namespace ProductManager.Dtos.Product
{
    public class CreateProductDto
    {
        private string _name;
        [Required]
        [StringLength(50)]
        public string Name
        {
            get => _name;
            set => _name = value?.Trim();
        }
        private string _description;
        [StringLength(50)]
        public string Description
        {
            get => _description;
            set => _description = value?.Trim();
        }
        public double Price { get; set; }
    }
}
