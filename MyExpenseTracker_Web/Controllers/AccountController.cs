using Microsoft.AspNetCore.Mvc;
using MyExpenseTrackerDal.Context;
using MyExpenseTrackerEntity.DTOs.Login;
using MyExpenseTrackerEntity.DTOs.User;
using MyExpenseTrackerEntity.Entities;
using Utility.Security;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace MyExpenseTrackerWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(UserCreateDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            if (_context.Users.Any(u => u.Email == dto.Email))
            {
                ModelState.AddModelError("Email", "Bu e-posta zaten kayıtlı.");
                return View(dto);
            }

            var hashedPassword = PasswordHasher.HashPassword(dto.Password);

            var user = new User
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = hashedPassword,
                Role = "User"
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            TempData["RegisterSuccess"] = "Kayıt başarılı! Giriş sayfasına yönlendiriliyorsunuz...";

            return RedirectToAction("Register");
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (!ModelState.IsValid) return View(dto);

            var user = _context.Users.FirstOrDefault(u => u.Email == dto.Email);
            if (user == null || !PasswordHasher.VerifyPassword(dto.Password, user.Password))
            {
                ModelState.AddModelError("", "Geçersiz e-posta veya şifre.");
                return View(dto);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [Authorize]
        public IActionResult Profile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // GUID string olarak gelir
            var user = _context.Users.FirstOrDefault(u => u.Id.ToString() == userId);
            if (user == null) return RedirectToAction("Login");

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
        [Authorize]
        public IActionResult Profile(UserUpdateDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var user = _context.Users.FirstOrDefault(u => u.Id == dto.Id);
            if (user == null)
                return NotFound();

            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Password = PasswordHasher.HashPassword(dto.Password); // şifre yeniden hashlenir

            _context.Users.Update(user);
            _context.SaveChanges();

            TempData["Success"] = "Profil bilgileri güncellendi.";
            return RedirectToAction("Profile");
        }

    }
}