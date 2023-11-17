namespace Task.Services.Abstract
{
    public interface IEnvanterService 
    {
        
        Task<DataResponse<int>> GetEnvanterStock(int envanterId);
        bool EnvanterExist(int envanterId);
    }
}
