using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Task.Data;
using Task.DTOs;
using Task.Services.Abstract;

namespace Task.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICategoryService _categoryService;
        private readonly IEnvanterService _envanterService;
        private readonly IMapper _mapper;

        public ProductService(ApplicationDbContext context, ICategoryService categoryService, 
                            IEnvanterService envanterService, IMapper mapper)
        {
            _context = context;
            _categoryService = categoryService;
            _envanterService = envanterService;
            _mapper = mapper;
        }

        public async Task<DataResponse<ProductDetailResponseDTO>> GetProductDetail(int productId)
        {
            ProductDetailResponseDTO response = new();
            var product =await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
            
            if(product == null)
            {
                return new DataResponse<ProductDetailResponseDTO> { Data = null, Message = "Product Does not Exist", Success = false };
            };
            
            var suggestions = await _context.Products.Include(p=>p.Envanter.Category).Where(P => P.Id != productId && P.EnvanterId == product.EnvanterId).ToListAsync();

            var productDetail = _mapper.Map<ProductDetailDTO>(product);
            var suggestionsDTO = _mapper.Map<List<ProductDTO>>(suggestions);
            response.Products = suggestionsDTO;
            response.ProductDetailDTO = productDetail;

            return new DataResponse<ProductDetailResponseDTO>
            {
                Data = response,
                Message = "Product detail getted",
                Success = true
            };

        }

        public async Task<DataResponse<ProductResponseDTO>> GetProductsByCategory(int categoryId)
        {
            ProductResponseDTO response = new ProductResponseDTO();
            var categoryExist =  _categoryService.CategoryExist(categoryId);
            if (!categoryExist.Success)
            {
                return new DataResponse<ProductResponseDTO>
                { Data = response, Message = "Category does not exist", Success = false };
            } 
         
            var envanter = await _envanterService.GetEnvanterStock(categoryId);

            if(!envanter.Success)
            {
                return new DataResponse<ProductResponseDTO>
                {
                    Message = envanter.Message,
                    Success = false,
                    Data = response
                };
            }
            response.QuantityInStock = envanter.Data;

            var products = await _context.Products.Include(p => p.Envanter).Where(P => P.Envanter.CategoryId == categoryId).ToListAsync();
            response.Products = _mapper.Map<List<ProductDTO>>(products);

            if (response.Products.Count() < 1)
            {
                return new DataResponse<ProductResponseDTO>
                {
                    Message = "There is no product in that category", Success = false, Data = response
                };
            }
           
            return new DataResponse<ProductResponseDTO>
            {
                Data = response,
                Message = "Product List getted",
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

            response.Products = _mapper.Map<List<ProductDTO>>(products);
            response.QuantityInStock = (await _envanterService.GetEnvanterStock(categoryId)).Data;

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
