using eTickets_Web.Data;
using eTickets_Web.Data.ViewModels;
using eTickets_Web.Data.Static;
using eTickets_Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eTickets_Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signinManager, AppDbContext context)
        {
            _userManager = userManager;  
            _signinManager = signinManager;  
            _context = context;  
        }

        // Login view(get) kısmı
        public IActionResult Login()
        {
            var response = new LoginVM();

            return View(response);
        }

        // POST: AccountController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginVM loginVM)
        {
            // Öncelikle Modelimin içerği geçerli bir içerik mi
            if (!ModelState.IsValid) return View(loginVM);

            // view ekranından girilmiş olan email adresi kayıtlarımda mevcut mu
            var user = await _userManager.FindByEmailAsync(loginVM.EMailAddress);

            if (user != null) // Kullanıcının varolması durumu
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password); // Password değeri kontrol edilicek

                if (passwordCheck) // true? false?
                {
                    var result = await _signinManager.PasswordSignInAsync(user, loginVM.Password,false,false);

                    if (result.Succeeded) // eğer başarılıysa
                    {
                        return RedirectToAction("Index", "Movies"); // herşey doğruysa Movies'e git film listesini göster)
                    }

                    TempData["Error"] = "Yanlış kullanıcı adı veya şifre..Lütfen tekrar deneyiniz..";

                    return View(loginVM);
                }
            }

            TempData["Error"] = "Yanlış kullanıcı adı veya şifre..Lütfen tekrar deneyiniz..";

            return View(loginVM);
        }

        // GET: Register ekranı
        public ActionResult Register()
        {
            var response=new RegisterVM();

            return View(response);
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
