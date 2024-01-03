using FirstWebCoreApplication.Models;
using FirstWebCoreApplication.Models.Data;
using FirstWebCoreApplication.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstWebCoreApplication.Controllers
{
    public class CategoryController : Controller
    {
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
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }

        public IActionResult Add()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Category category)
        {
            bool result = await categoryService.AddCategoryAsync(category);

            ViewData["Message"] = result ? "Category Added Successful" : "Category Added Error";

            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var category = await categoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            bool result = await categoryService.UpdateCategoryAsync(category);

            ViewData["Message"] = result ? "Category Edit Successful" : "Category Edit Error";

            return View(category);
        }
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await categoryService.DeleteCategoryAsync(id);
            TempData["Message"] = result ? "Category Deleted Successful" : "Category Deleted Error";

            return RedirectToAction("Index");
        }
    }
}
