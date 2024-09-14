using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoccerShoesShop.Models;
using SoccerShoesShop.Services;

namespace SoccerShoesShop.Controllers.Admin
{
    [Route("Admin/[controller]/[action]/{id?}")]
    [Authorize(Policy = "AdminOnly")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.getAllCategoriesAsync();
            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var category = await _categoryService.getCategoryByIdAsync(id);
            if (category == null) return View("Error");
            return View(category);
        }

        [HttpGet]
        public IActionResult Create() => View("CreateOrEdit", new Category());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.AddCategoryAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View("CreateOrEdit", category);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryService.getCategoryByIdAsync(id);
            if (category == null)
                return View("Error");
            return View("CreateOrEdit", category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.UpdateCategoryAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View("CreateOrEdit", category);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
