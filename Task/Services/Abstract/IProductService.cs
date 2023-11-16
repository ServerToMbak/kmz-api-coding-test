using Task.DTOs;
using Task.Entities;

namespace Task.Services.Abstract
{
    public interface IProductService
    {
        Task<DataResponse<ProductResponseDTO>> GetProductsByCategory(int categoryId);
        Task<DataResponse<ProductResponseDTO>> GetProductsByCategory(int categoryId, string? ordering);
    }
}
