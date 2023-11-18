using Task.DTOs;
using Task.Entities;

namespace Task.Services.Abstract
{
    public interface IProductService
    {
        Task<DataResponse<ProductResponseDTO>> GetProductsByCategory(int? categoryId, string? brand, string? orderBy);
        Task<DataResponse<ProductDetailResponseDTO>> GetProductDetail(int productId);
        DataResponse<List<Product>> GetAllProducts();
    }
}
