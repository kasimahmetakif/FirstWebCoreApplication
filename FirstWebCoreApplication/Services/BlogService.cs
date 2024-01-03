using FirstWebCoreApplication.Models;
using FirstWebCoreApplication.Models.Data;
using FirstWebCoreApplication.Models.Interfaces;

namespace FirstWebCoreApplication.Services
{
    public class BlogService : IBlogService
    {
        //veritabanı ekleme
        ApplicationDbContext db;
        public BlogService(ApplicationDbContext _db)
        {
            db = _db;
        }
        /// /////////////////////////////////////////////////////

        public async Task<bool> AddBlogAsync(Blog blog, int categoryId)
        {
            var result = false;
            if (!String.IsNullOrEmpty(blog.Name))
            {
                blog.CreateDate = DateTime.Now;
                blog.UserId = 1; // Bu sabit değeri dinamik hale getirmeyi düşünün
                await db.Blog.AddAsync(blog);
                await db.SaveChangesAsync();

                var blogCategory = new BlogCategory()
                {
                    BlogId = blog.Id,
                    CategoryId = categoryId
                };
                await db.BlogCategory.AddAsync(blogCategory);
                await db.SaveChangesAsync();
                result = true;
            }
            return result;
        }

        public Task<bool> DeleteBlogAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Blog> GetBlogByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Blog>> GetBlogListAsync()
        {
            var blogList = db.Blog.Where(x => x.IsDelete == false).ToList();
            return Task.FromResult(blogList);
        }

        public Task<List<Blog>> GetBlogListByCategoryAsync(int category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateBlogAsync(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
