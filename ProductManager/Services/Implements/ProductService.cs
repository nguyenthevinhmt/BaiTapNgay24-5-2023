using ProductManager.Contexts;
using ProductManager.Dtos.Filter;
using ProductManager.Dtos.Product;
using ProductManager.Entities;
using ProductManager.Services.Interfaces;

namespace ProductManager.Services.Implements
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public string CreateProduct(CreateProductDto input)
        {
            var result = _context.Products.Add(new Product
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
            var check = _context.Products.FirstOrDefault(Product => Product.Id == id);
            if (check == null)
            {
                throw new Exception("Sản phẩm không tồn tại");
            }
            _context.Products.Remove(check);
            _context.SaveChanges();
            return "Xóa thành công";
        }

        public ProductDto GetProductById(int id)
        {
            var result = _context.Products.FirstOrDefault(c => c.Id == id);
            if (result == null)
            {
                throw new Exception("Sản phẩm không tồn tại");
            }
            return new ProductDto { Name = result.Name, Description = result.Description, Price = result.Price };
        }

        public PageResultDto<ProductDto> GetProducts(ProductFilterDto input)
        {
            var productQuery = _context.Products.AsQueryable();
            productQuery = productQuery.Where(s => (input.Keyword == null || s.Name.ToLower().Contains(input.Keyword))
                                            && (input.FromPrice == null || s.Price >= input.FromPrice)
                                            && (input.ToPrice == null || s.Price <= input.ToPrice))
                                        .OrderByDescending(x => x.Price)
                                        .ThenByDescending(x => x.Id);

            int totalItem = productQuery.Count();
            productQuery = productQuery.Skip(input.PageSize * (input.PageIndex - 1))
                .Take(input.PageSize);
            var result = productQuery.Select(p => new ProductDto
            {
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
            });
            return new PageResultDto<ProductDto>
            {
                Items = result,
                TotalItem = totalItem,
            };
        }

        public string UpdateProduct(UpdateProductDto input)
        {
            var check = _context.Products.FirstOrDefault(p => p.Id == input.Id);
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
