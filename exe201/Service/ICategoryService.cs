using exe201.Models;

namespace exe201.Service
{
    public interface ICategoryService
    {
        List<Category> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Category CreateAsync(Category category);
        Task<bool> DeleteAsync(int id);
        Task<Category> UpdateAsync(int id, Category category);
    }
}
