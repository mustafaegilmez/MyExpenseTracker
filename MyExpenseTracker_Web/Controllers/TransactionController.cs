using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyExpenseTrackerEntity.DTOs.Transaction;
using MyExpenseTrackerEntity.Entities;
using MyExpenseTrackerService;
using System.Security.Claims;

namespace MyExpenseTrackerWeb.Controllers
{
    public class TransactionController : Controller
    {
        private readonly TransactionService _transactionService;
        private readonly CategoryService _categoryService;

        public TransactionController(TransactionService transactionService, CategoryService categoryService)
        {
            _transactionService = transactionService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var userId);

            var transactions = _transactionService.GetAll()
                .Where(t => t.UserId == userId)
                .Select(t => new TransactionListDto
                {
                    Id = t.Id,
                    Amount = t.Amount,
                    Description = t.Description,
                    Date = t.Date,
                    UserFullName = t.User.FullName,
                    CategoryName = t.Category.Name
                }).ToList();

            return View(transactions);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var userId);

            ViewBag.Categories = _categoryService.GetAll()
                .Where(c => c.UserId == userId)
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList();

            return View(new TransactionCreateDto());
        }

        [HttpPost]
        public IActionResult Create(TransactionCreateDto dto)
        {
            if (!ModelState.IsValid) return View(dto);
            if (dto.Amount <= 0)
            {
                ModelState.AddModelError("Amount", "Tutar 0'dan büyük olmalıdır.");
            }

            Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var userId);

            var transaction = new Transaction
            {
                Amount = dto.Amount,
                Description = dto.Description,
                Date = dto.Date,
                CategoryId = dto.CategoryId,
                UserId = userId
            };

            _transactionService.Add(transaction);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var transaction = _transactionService.GetById(id);
            if (transaction == null) return NotFound();

            var dto = new TransactionUpdateDto
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                Description = transaction.Description,
                Date = transaction.Date,
                CategoryId = transaction.CategoryId
            };

            ViewBag.Categories = _categoryService.GetAll()
                .Where(c => c.UserId == transaction.UserId)
                .Select(c => new SelectListItem
                {
                    Text = c.Name,
                    Value = c.Id.ToString()
                }).ToList();

            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(TransactionUpdateDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var entity = _transactionService.GetById(dto.Id);
            if (entity == null) return NotFound();

            entity.Amount = dto.Amount;
            entity.Description = dto.Description;
            entity.Date = dto.Date;
            entity.CategoryId = dto.CategoryId;

            _transactionService.Update(entity);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _transactionService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}