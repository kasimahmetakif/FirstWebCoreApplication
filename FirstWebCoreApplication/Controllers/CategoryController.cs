using FirstWebCoreApplication.Models.Data;
using FirstWebCoreApplication.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstWebCoreApplication.Controllers
{
    public class CategoryController : Controller
    {
        /// düz bir şekilde veritabanı bağlantısı yapmak için
        ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {

            return View(categoryService.GetAllCategoriesAsync());

        }

        public async Task<IActionResult> DetailAsync(int id)
        {
            var category = await categoryService.GetCategoryByIdAsync(id);
            if(category == null)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }

    }
}
