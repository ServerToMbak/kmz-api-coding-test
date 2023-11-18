using AutoMapper;
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
        private readonly IMapper _mapper;

        public ProductService(ApplicationDbContext context, IMapper mapper,ICategoryService categoryService)
        {
            _context = context;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public DataResponse<List<Product>> GetAllProducts()
        {
            var data = _context.Products.Include(p=>p.EnvanterItems).ThenInclude(p=>p.Envanter).ToList();
            if (data == null)
            {
                return new DataResponse<List<Product>> { Data = data, Message = "There is no product", Success = false };
            }
            return new DataResponse<List<Product>> { Success = true, Data = data, Message= "products getted" };
                
        }

        public async Task<DataResponse<ProductDetailResponseDTO>> GetProductDetail(int productId)
        {
            ProductDetailResponseDTO response = new();
            var product = await _context.Products.Include(p=>p.Category).Include(p=>p.EnvanterItems).ThenInclude(p=>p.Envanter).FirstOrDefaultAsync(p => p.Id == productId);
            
            if(product == null)
            {
                return new DataResponse<ProductDetailResponseDTO> { Data = null, Message = "Product Does not Exist", Success = false };
            };
            
            var suggestions = await _context.Products.Include(p => p.EnvanterItems).Include(p=>p.Category).Where(P => P.Id != productId).ToListAsync();

            var productDetail = _mapper.Map<ProductDetailDTO>(product);
            var suggestionsDTO = _mapper.Map<List<ProductDTO>>(suggestions);

            response.Suggestions = suggestionsDTO;
            response.ProductDetailDTO = productDetail;

            return new DataResponse<ProductDetailResponseDTO>
            {
                Data = response,
                Message = "Product detail getted",
                Success = true
            };

        }

        public async Task<DataResponse<ProductResponseDTO>> GetProductsByCategory(int? categoryId = null, string brand = null, string orderBy = "name")
        {
            ProductResponseDTO response = new ProductResponseDTO();

            var productListResponse = GetAllProducts();
            if(!productListResponse.Success)
            {
                return new DataResponse<ProductResponseDTO>
                { Data = response, Message = productListResponse.Message, Success = false };
            }
            var productList = productListResponse.Data;
            //Category Filter 
            if (categoryId.HasValue)
            {
                var categoryExist = _categoryService.CategoryExist(categoryId.Value);
                if (!categoryExist.Success)
                {
                    return new DataResponse<ProductResponseDTO>
                    { Data = response, Message = categoryExist.Message, Success = false };
                }
                productList = productList.Where(p => p.CategoryId == categoryId.Value).ToList();
            }

            //brand name filter
            if (!string.IsNullOrEmpty(brand))
            {
                productList = productList.Where(p => p.BrandName.ToLower() == brand.ToLower()).ToList();
            }

            if (productList.Count == 0)
            {
                return new DataResponse<ProductResponseDTO>
                {
                    Message = "There is no product in that category",
                    Success = false,
                    Data = response
                };
            }
            // Price Filter
            if (!string.IsNullOrEmpty(orderBy))
            {
                if(orderBy == "asc")
                    productList = productList.OrderBy(p => p.Price).ToList();
                
                else if(orderBy == "desc")
                    productList = productList.OrderByDescending(p => p.Price).ToList();
            }


            response.Products = _mapper.Map<List<ProductDTO>>(productList);

           
            return new DataResponse<ProductResponseDTO>
            {
                Data = response,
                Message = "Product List getted",
                Success = true
            };

        }
    }
}
