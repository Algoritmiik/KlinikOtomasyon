using KlinikOtomasyon.Entities.Concrete;
using KlinikOtomasyon.MVC.Models.ResultModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace KlinikOtomasyon.MVC.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Login(string returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl))
            {
                ViewBag.returnUrl = returnUrl;
            }
            return await Task.Run(() => View());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AccountLoginResultModel loginModel, string? returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(loginModel.Name);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();
                    var result = await _signInManager.PasswordSignInAsync(user, loginModel.PasswordHash, false, false);
                    if (result.Succeeded)
                    {
                        return Redirect(returnUrl ?? "/");
                    }
                    else
                    {
                        ModelState.AddModelError("PasswordHash", "Lütfen Şifrenizi Kontrol Ediniz");
                        return View(loginModel);
                    }
                }
                ModelState.AddModelError("Email", "Böyle bir kullanıcı bulunamadı");
            }
            return View(loginModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }

        public async Task<IActionResult> AccessDenied()
        {
            return await Task.Run(() => RedirectToAction("Error", "Home"));
        }
    }
}