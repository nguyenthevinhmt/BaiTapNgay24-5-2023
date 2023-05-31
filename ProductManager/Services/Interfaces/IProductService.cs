using ProductManager.Dtos.Filter;
using ProductManager.Dtos.Product;

namespace ProductManager.Services.Interfaces
{
    public interface IProductService
    {
        PageResultDto<ProductDto> GetProducts(ProductFilterDto input);
        ProductDto GetProductById(int id);
        string CreateProduct(CreateProductDto input);
        string UpdateProduct(UpdateProductDto input);
        string DeleteProduct(int id);

    }
}
