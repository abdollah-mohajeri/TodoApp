using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // مثال ساده از ورود
            if (username == "admin" && password == "12345")
            {
                // اگر ورود موفقیت‌آمیز بود، کاربر را به صفحه Todo هدایت می‌کنیم
                return RedirectToAction("Index", "Todo");
            }

            // اگر ورود موفق نبود، خطا را به ViewData ارسال می‌کنیم
            ViewData["Error"] = "Invalid username or password.";
            return View();  // فرم لاگین دوباره بارگذاری می‌شود
        }

        // GET: /Account/SignUp
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        // POST: /Account/SignUp
        [HttpPost]
        public IActionResult SignUp(string email, string username, string password, string passwordConfirm)
        {
            if (password != passwordConfirm)
            {
                // اگر رمزها با هم مطابقت نداشته باشند، خطا به ViewData ارسال می‌شود
                ViewData["Error"] = "Passwords do not match.";
                return View(); // فرم ثبت‌نام دوباره بارگذاری می‌شود
            }

            // اگر ثبت‌نام موفق بود، به صفحه لاگین هدایت می‌کنیم
            return RedirectToAction("Login");
        }
    }
}
