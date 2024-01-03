using FirstWebCoreApplication.Models;
using FirstWebCoreApplication.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebCoreApplication.Controllers
{
    public class BlogController : Controller
    {
        IBlogService blogService;
        ICategoryService categoryService;
        public BlogController(IBlogService blogService, ICategoryService categoryService)
        {
            this.blogService = blogService;
            this.categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var list = await blogService.GetBlogListAsync();
            return View(list);
        }

        public async Task<IActionResult> Add()
        {
            var categoryList = await categoryService.GetAllCategoriesAsync();
            return View(categoryList);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Blog blog, int categoryId)
        {
            var result = await blogService.AddBlogAsync(blog, categoryId);
            TempData["Message"]=result ? "Blog başarıyla eklendi" : "Blog eklenirken bir hata oluştu";
            return RedirectToAction("Index");
        }
    }
}
