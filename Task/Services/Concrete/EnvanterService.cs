using Microsoft.EntityFrameworkCore;
using Task.Data;
using Task.Services.Abstract;

namespace Task.Services.Concrete
{
    public class EnvanterService : IEnvanterService
    {
        private readonly ApplicationDbContext _context;

        public EnvanterService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool EnvanterExist(int envanterId)
        {
            var envanter =  _context.Envanters.Where(e=>e.Id == envanterId).Any();
            return envanter;
        }

        public async Task<DataResponse<int>> GetEnvanterStock(int envanterId)
        {
            if(!EnvanterExist(envanterId))
            {
                return new DataResponse<int> { Message = "Envanter Does  not Exist", Success=false };
            }
            var envanter = await _context.Envanters.Where(o => o.Id == envanterId).FirstOrDefaultAsync();

            return new DataResponse<int>
            {
                Data = envanter.QuantityInStock,
                Success = true,
                Message = "Envanter Stock number getted"
            };
        }
    }
}
