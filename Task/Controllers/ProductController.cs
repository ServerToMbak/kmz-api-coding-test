using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task.Data;
using Task.DTOs;
using Task.Entities;
using Task.Services.Abstract;

namespace Task.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ApplicationDbContext _context;

        public ProductController(IProductService productService, ApplicationDbContext context)
        {
            _productService = productService;
            _context = context;
        }


        [HttpGet("2.1")]
        public async Task<ActionResult> GetProductsByCategoryId(int? categoryId, string? ASCORDESC, string? brandName)
        {
            var response = await _productService.GetProductsByCategory(categoryId, brandName, ASCORDESC);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }

        [HttpGet("2.2")]
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
