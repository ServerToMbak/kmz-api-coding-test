using Microsoft.AspNetCore.Mvc;
using Task.DTOs;
using Task.Services.Abstract;

namespace Task.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<ActionResult> GetProductsByCategoryId(int categoryId, string? ASCORDESC)
        {
            DataResponse<ProductResponseDTO> response;
            if(ASCORDESC == null)
            {
                response = await _productService.GetProductsByCategory(categoryId);
            }
            else
            {
                response = await _productService.GetProductsByCategory(categoryId, ASCORDESC);
            }
           
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }

        [HttpGet("productdetail")]
        public async Task<ActionResult<ProductDetailResponseDTO>> GetProductDetai(int id)
        {
            var response = await _productService.GetProductDetail(id);
            if(response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }
}
