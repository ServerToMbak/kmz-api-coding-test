using Task.Data;
using Task.Services.Abstract;

namespace Task.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public DataResponse<bool> CategoryExist(int categoryId)
        {
            var categoryExist = _context.Categories.Any(c=> c.Id == categoryId);
            if(categoryExist)
            {
                return new DataResponse<bool> {Data=true, Message = "Category Exist", Success = true };
            }
            return new DataResponse<bool>
            { Message = "Category Does not Exist!", Success = false, Data = false };
        }
    }
}
