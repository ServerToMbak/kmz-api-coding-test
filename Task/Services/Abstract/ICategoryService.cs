namespace Task.Services.Abstract
{
    public interface ICategoryService
    {
        DataResponse<bool> CategoryExist(int categoryId);
    }
}
