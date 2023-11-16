using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult> GetProductsByCategoryId(int id, string? ordering)
        {
            if(ordering == null)
            {
                var response = await _productService.GetProductsByCategory(id);
                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);
            }
            var responseOrdered = await _productService.GetProductsByCategory(id,ordering);
            if (responseOrdered.Success)
            {
                return Ok(responseOrdered);
            }
            return BadRequest(responseOrdered);

        }
    }
}
