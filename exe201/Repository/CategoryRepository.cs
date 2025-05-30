using exe201.Models;
using Microsoft.EntityFrameworkCore;

namespace exe201.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly EcommerceContext _context;
        public CategoryRepository(EcommerceContext context)
        {
            _context = context;
        }

        public Category CreateAsync(Category category)
        {
            category.CreatedAt = DateTime.Now;
            _context.Categories.Add(category);
            _context.SaveChanges();  
            return category; 
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if(category == null)
            {
                return false;
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return true;
        }

        public List<Category> GetAllAsync()
        {
            try
            {
                return _context.Categories.ToList();
            }catch(TaskCanceledException ex)
            {
                Console.WriteLine($"TaskCanceledException: {ex.Message} InnerException: {ex.InnerException}");
                throw;
            }catch(Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                throw;
            }
            
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            var existingCategory = await _context.Categories.FindAsync(category.Id);
            if(existingCategory == null)
            {
                return null;
            }
            existingCategory.Name = category.Name;
            await _context.SaveChangesAsync();
            return existingCategory;
        }
    }
}
