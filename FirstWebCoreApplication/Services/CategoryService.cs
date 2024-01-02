using FirstWebCoreApplication.Models;
using FirstWebCoreApplication.Models.Data;
using FirstWebCoreApplication.Models.Interfaces;

namespace FirstWebCoreApplication.Services
{
    public class CategoryService : ICategoryService
    {
        ApplicationDbContext db;
        public CategoryService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public Task<bool> AddCategoryAsync(Category category)
        {
            var result = false;
            if (!String.IsNullOrEmpty(category.Name))
            {
                db.Category.AddAsync(category);
                db.SaveChangesAsync();

                result = true;
            }
            return Task.FromResult(result);

        }

        public Task<bool> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAllCategoriesAsync()
        {
            var categoryList = db.Category.Where(x=>!x.IsDelete).ToList();
            return Task.FromResult(categoryList);
        }

        public Task<Category> GetCategoryByIdAsync(int id)
        {
            var category = db.Category.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(category);
        }

        public Task<bool> UpdateCategoryAsync(Category category, int id)
        {
            throw new NotImplementedException();
        }
    }
}
