namespace FirstWebCoreApplication.Models.Interfaces
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetAllCategoriesAsync();
        public Task<Category> GetCategoryByIdAsync(int id);
        public Task<bool> UpdateCategoryAsync(Category category);
        public Task<bool> DeleteCategoryAsync(int id);
        public Task<bool> AddCategoryAsync(Category category);
    }
}
