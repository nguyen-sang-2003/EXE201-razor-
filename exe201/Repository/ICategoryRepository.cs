using exe201.Models;

namespace exe201.Repository
{
    public interface ICategoryRepository
    {
        List<Category> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Category CreateAsync(Category category);
        //Task<Category> CreateCategory();
        Task<bool> DeleteAsync(int id);
        Task<Category> UpdateAsync(Category category);
    }
}
