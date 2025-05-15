using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyExpenseTrackerEntity.DTOs.Category;
using MyExpenseTrackerEntity.Entities;
using MyExpenseTrackerService;
using System.Security.Claims;

namespace MyExpenseTrackerWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var userId);

            var categories = _categoryService.GetAll()
                .Where(c => c.UserId == userId)
                .Select(c => new CategoryListDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Type = c.Type,
                    IsDefault = c.IsDefault
                }).ToList();

            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CategoryCreateDto());
        }

        [HttpPost]
        public IActionResult Create(CategoryCreateDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var userId);

            var category = new Category
            {
                Name = dto.Name,
                Type = dto.Type,
                IsDefault = dto.IsDefault,
                UserId = userId
            };

            _categoryService.Add(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var c = _categoryService.GetById(id);
            if (c == null) return NotFound();

            var dto = new CategoryUpdateDto
            {
                Id = c.Id,
                Name = c.Name,
                Type = c.Type,
                IsDefault = c.IsDefault
            };

            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(CategoryUpdateDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var category = _categoryService.GetById(dto.Id);
            if (category == null) return NotFound();

            category.Name = dto.Name;
            category.Type = dto.Type;
            category.IsDefault = dto.IsDefault;

            _categoryService.Update(category);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _categoryService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
