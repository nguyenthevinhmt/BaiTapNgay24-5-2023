using ProductManager.Contexts;
using ProductManager.Dtos.Filter;
using ProductManager.Dtos.Product;
using ProductManager.Entities;
using ProductManager.Services.Interfaces;

namespace ProductManager.Services.Implements
{
    public class ProductService : IProduct
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public string CreateProduct(CreateProductDto input)
        {
            var result = _context.products.Add(new Product
            {
                Name = input.Name,
                Description = input.Description,
                Price = input.Price,
            });
            _context.SaveChanges();
            return "Thêm thành công ";
        }

        public string DeleteProduct(int id)
        {
            var check = _context.products.FirstOrDefault(Product => Product.Id == id);
            if (check != null)
            {
                throw new Exception("Sản phẩm không tồn tại");
            }
            _context.products.Remove(check);
            _context.SaveChanges();
            return "Xóa thành công";
        }

        public CreateProductDto GetProductById(int id)
        {
            var result = _context.products.FirstOrDefault(c => c.Id == id);
            if (result == null)
            {
                throw new Exception("Sản phẩm không tồn tại");
            }
            return new CreateProductDto { Name = result.Name, Description = result.Description, Price = result.Price };

        }

        public PageResultDto<List<Product>> GetProducts(FilterDto input)
        {
            var productQuery = _context.products.AsQueryable();
            if (input.Keyword != null)
            {
                productQuery = productQuery.Where(s => s.Name.ToLower().Contains(input.Keyword));
                //or s.Name?.Contains(input.Keyword) ?? false
            }
            int totalItem = productQuery.Count();
            productQuery = productQuery.Skip(input.PageSize * (input.PageIndex - 1))
                .Take(input.PageSize);

            return new PageResultDto<List<Product>>
            {
                Items = productQuery.ToList(),
                TotalItem = totalItem,
            };

        }

        public string UpdateProduct(UpdateProductDto input)
        {
            var check = _context.products.FirstOrDefault(p => p.Id == input.Id);
            if (check == null)
            {
                throw new Exception("Sản phẩm không tồn tại");
            }
            check.Name = input.Name;
            check.Description = input.Description;
            check.Price = input.Price;
            _context.SaveChanges();
            return "Cập nhật thành công";
        }
    }
}
