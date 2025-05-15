using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyExpenseTrackerEntity.DTOs.User;
using MyExpenseTrackerEntity.Entities;
using MyExpenseTrackerService;

namespace MyExpenseTrackerWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var users = _userService.GetAll()
                .Select(u => new UserListDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Role = u.Role
                }).ToList();

            return View(users);
        }

        [HttpGet]
        public IActionResult Create() => View(new UserCreateDto());

        [HttpPost]
        public IActionResult Create(UserCreateDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = dto.Password,
                Role = "User"
            };

            _userService.Add(user);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var user = _userService.GetById(id);
            if (user == null) return NotFound();

            var dto = new UserUpdateDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role
            };

            return View(dto);
        }

        [HttpPost]
        public IActionResult Edit(UserUpdateDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var user = _userService.GetById(dto.Id);
            if (user == null) return NotFound();

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Email = dto.Email;
            user.Password = dto.Password;
            user.Role = dto.Role;

            _userService.Update(user);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Guid id)
        {
            _userService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}