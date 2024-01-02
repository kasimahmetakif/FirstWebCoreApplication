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
        /// /////////////////////////////////////////////////////
        public IActionResult Index()
        {
            var categoryList = db.Category.ToList();
            return View(categoryList);
        }
    }
}
