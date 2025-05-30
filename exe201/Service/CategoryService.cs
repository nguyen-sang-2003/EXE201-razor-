using exe201.Models;
using exe201.Repository;

namespace exe201.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _Repo;
        public CategoryService(ICategoryRepository repo)
        {
            _Repo = repo;
        }

        public Category CreateAsync(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
            {
                throw new ArgumentException("Category name cannot be empty");
            }
            return _Repo.CreateAsync(category);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _Repo.DeleteAsync(id);
        }

        public List<Category> GetAllAsync()
        {
            return _Repo.GetAllAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _Repo.GetByIdAsync(id);    
        }

        public async Task<Category> UpdateAsync(int id,Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
            {
                throw new ArgumentException("Category name cannot be empty");
            }
            category.Id = id;
            var updateCategory = await _Repo.UpdateAsync(category);
            if(updateCategory == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }
            return updateCategory;
        }
    }
}
