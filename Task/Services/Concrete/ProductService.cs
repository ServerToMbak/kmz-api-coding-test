using Azure;
using Microsoft.EntityFrameworkCore;
using Task.Data;
using Task.DTOs;
using Task.Entities;
using Task.Services.Abstract;

namespace Task.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICategoryService _categoryService;

        public ProductService(ApplicationDbContext context, ICategoryService categoryService)
        {
            _context = context;
            _categoryService = categoryService;
        }

        public async Task<DataResponse<ProductResponseDTO>> GetProductsByCategory(int categoryId)
        {
            ProductResponseDTO response = new ProductResponseDTO();
            var categoryExist =  _categoryService.CategoryExist(categoryId);
            if (!categoryExist.Success)
            {
                return new DataResponse<ProductResponseDTO>
                { Data = null, Message = "Category does not exist", Success = false };
            } 
            var products =await _context.Products.Include(p=>p.Envanter).Where( P => P.Envanter.CategoryId == categoryId).ToListAsync();
     
            foreach (var product in products) 
            {
                ProductDTO resposneItem = new();
                resposneItem.ProductName = product.Name ;
                resposneItem.Price = product.Price;
                resposneItem.BrandName = product.Envanter.BrandName ;
                response.Products.Add(resposneItem);   
            }
             
            
            if (response.Products is null)
            {
                return new DataResponse<ProductResponseDTO>
                {
                    Message = "There is no product in that category", Success = false
                };
            }
           
            return new DataResponse<ProductResponseDTO>
            {
                Data = response,
                Message = "Products List getted",
                Success = true
            };

        }



        public async Task<DataResponse<ProductResponseDTO>> GetProductsByCategory(int categoryId, string? fiyat)
        {
            ProductResponseDTO response = new ProductResponseDTO();
            var categoryExist = _categoryService.CategoryExist(categoryId);
            if (!categoryExist.Success)
            {
                return new DataResponse<ProductResponseDTO>
                { Data = null, Message = "Category does not exist", Success = false };
            }


            var products = await _context.Products.Include(p => p.Envanter).Where(P => P.Envanter.CategoryId == categoryId).ToListAsync();
            if (fiyat == "ASC")
            {
                products = products.OrderBy(p => p.Price).ToList();
            }
            else if(fiyat == "DESC")
            {

                products = products.OrderByDescending(p => p.Price).ToList();
            }
          

            foreach (var product in products)
            {
                ProductDTO resposneItem = new();
                resposneItem.ProductName = product.Name;
                resposneItem.Price = product.Price;
                resposneItem.BrandName = product.Envanter.BrandName;
                response.Products.Add(resposneItem);
            }


            if (response.Products is null)
            {
                return new DataResponse<ProductResponseDTO>
                {
                    Message = "There is no product in that category",
                    Success = false
                };
            }

            return new DataResponse<ProductResponseDTO>
            {
                Data = response,
                Message = "Products List getted",
                Success = true
            };

        }
    }
}
