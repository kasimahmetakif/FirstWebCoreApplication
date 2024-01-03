using FirstWebCoreApplication.Models;
using FirstWebCoreApplication.Models.Data;
using FirstWebCoreApplication.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
                db.SaveChanges();

                result = true;
            }
            return Task.FromResult(result);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var getCategory = await GetCategoryByIdAsync(id);
            var result = false;
            if (getCategory != null)
            {
                getCategory.IsDelete = true;
                db.SaveChanges();

                result = true;
            }
            return result;
        }

        public Task<List<Category>> GetAllCategoriesAsync()
        {
            var categoryList = db.Category.Where(x => !x.IsDelete).ToList();
            return Task.FromResult(categoryList);
        }

        
        public Task<Category> GetCategoryByIdAsync(int id)
        {
            var category = db.Category.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(category);
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            var getCategory = await GetCategoryByIdAsync(category.Id);
            var result = false;
            if (getCategory != null && category.Name != null)
            {
                getCategory.Name = category.Name;
                getCategory.Description = category.Description;
                getCategory.IsStatus = category.IsStatus;
                db.SaveChanges();
                result = true;
            }

            return result;
        }

    }
}
