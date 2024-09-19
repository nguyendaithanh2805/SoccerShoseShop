using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SoccerShoesShop.Areas.Admin.Models;
using SoccerShoesShop.Areas.Admin.Services;

namespace SoccerShoesShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IImageService _imageService;

        public ProductController(IProductService productService, ICategoryService categoryService, IImageService imageService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _imageService = imageService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create() {
            var categories = await _categoryService.getAllCategoriesAsync();
            if (categories is null || !categories.Any())
            {
                TempData["ErrorMessage"] = "You need to create at least one category before adding a product.";
                return RedirectToAction("Create", "Category", new { area = "Admin" });
            }
            ViewBag.Categories = new SelectList(categories, "CategoryId", "Name");
            return View("CreateOrEdit", new Product());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile is null) throw new ArgumentNullException("Image file is null");
                // Lay category dua tren categoryId tu form
                var category = await _categoryService.getCategoryByIdAsync(product.Category.CategoryId);
                if (category is null)
                {
                    ModelState.AddModelError("Error", "Selected catgory does not exist.");
                    return View("CreateOrEdit", product);
                }
                product.Category = category;

                var imagePath = await _imageService.UploadImageAsync(imageFile);
                product.Image = imagePath;
                await _productService.AddProductAsync(product);
                return RedirectToAction(nameof(Index));
            }
            var allCategories = await _categoryService.getAllCategoriesAsync();
            ViewBag.Categories = new SelectList(allCategories, "CategoryId", "Name");
            return View("CreateOrEdit", product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var categories = await _categoryService.getAllCategoriesAsync();
            if (categories is null || !categories.Any())
            {
                TempData["ErrorMessage"] = "You need to create at least one category before adding a product.";
                return RedirectToAction("Create", "Category", new { area = "Admin" });
            }
            ViewBag.Categories = new SelectList(categories, "CategoryId", "Name");

            var product = await _productService.GetProductByIdAsync(id);
            if (product is null) return View("Error");
            return View("CreateOrEdit", product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile is null) throw new ArgumentNullException("Image file is null");
                // Lay category dua tren categoryId tu form
                var category = await _categoryService.getCategoryByIdAsync(product.Category.CategoryId);
                if (category is null)
                {
                    ModelState.AddModelError("Error", "Selected catgory does not exist.");
                    return View("CreateOrEdit", product);
                }
                product.Category = category;

                var imagePath = await _imageService.UploadImageAsync(imageFile);
                product.Image = imagePath;
                await _productService.UpdateProductAsync(product);
                return RedirectToAction(nameof(Index));
            }
            var allCategories = await _categoryService.getAllCategoriesAsync();
            ViewBag.Categories = new SelectList(allCategories, "CategoryId", "Name");

            return View("CreateOrEdit", product);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
