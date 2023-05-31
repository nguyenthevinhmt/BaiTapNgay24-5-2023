using Microsoft.AspNetCore.Mvc;
using ProductManager.Dtos.Filter;

namespace ProductManager.Dtos.Product
{
    public class ProductFilterDto : FilterDto
    {
        [FromQuery(Name = "fromPrice")]
        public double? FromPrice { get; set; }
        [FromQuery(Name = "toPrice")]
        public double? ToPrice { get; set; }
    }
}
