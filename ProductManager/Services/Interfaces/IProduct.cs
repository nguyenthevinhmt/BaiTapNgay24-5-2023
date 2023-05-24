using ProductManager.Dtos.Filter;
using ProductManager.Dtos.Product;
using ProductManager.Entities;

namespace ProductManager.Services.Interfaces
{
    public interface IProduct
    {
        PageResultDto<List<Product>> GetProducts(FilterDto input);
        CreateProductDto GetProductById(int id);
        string CreateProduct(CreateProductDto input);
        string UpdateProduct(UpdateProductDto input);
        string DeleteProduct(int id);

    }
}
