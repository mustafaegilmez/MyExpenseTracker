using Microsoft.AspNetCore.Mvc;
using MyExpenseTrackerService;
using MyExpenseTrackerEntity.Entities;

namespace MyExpenseTrackerWeb.Controllers
{
    public class TransactionController : Controller
    {
        private readonly TransactionService _transactionService;

        public TransactionController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public IActionResult Index()
        {
            var transactions = _transactionService.GetAll();
            return View(transactions);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _transactionService.Add(transaction);
                return RedirectToAction("Index");
            }

            return View(transaction);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var t = _transactionService.GetById(id);
            if (t == null)
                return NotFound();

            return View(t);
        }

        [HttpPost]
        public IActionResult Edit(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _transactionService.Update(transaction);
                return RedirectToAction("Index");
            }

            return View(transaction);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _transactionService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}