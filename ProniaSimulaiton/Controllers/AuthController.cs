using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProniaSimulaiton.Models;
using ProniaSimulaiton.ViewModels.Auth;
using System.Threading.Tasks;

namespace ProniaSimulaiton.Controllers
{
    public class AuthController : Controller
    {
        UserManager<AppUser> _usermanager;
        RoleManager<IdentityRole> _roleManager;
        SignInManager<AppUser> _signInManager;
        public AuthController(UserManager<AppUser> usermanager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _usermanager = usermanager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }


        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm, string? ReturnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var user = await _usermanager.FindByEmailAsync(vm.Email);
            var result = await _signInManager.PasswordSignInAsync(user, vm.Password, false, false);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Istifadeci adi yaxud parol yanlisdir");
            }
            if (!String.IsNullOrEmpty(ReturnUrl))
            {
                return Redirect(ReturnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var existUserName = await _usermanager.FindByNameAsync(vm.UserName);

            if (existUserName != null)
            {
                ModelState.AddModelError("UserName", "Bu username artıq mövcuddur");
                return View(vm);
            }
            AppUser user = new()
            {
                UserName = vm.UserName,
                Email = vm.Email,
                Name = vm.Name,
                Surname = vm.Surname,
            };
            var result=await _usermanager.CreateAsync(user, vm.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                    return View();
                }
            }
            _usermanager.AddToRoleAsync(user, "Member");
            return RedirectToAction("Login","Auth");
        }
        public   async Task<IActionResult> SeedRoles()
        {
            var roles = Enum.GetNames(typeof(Roles));
            foreach (var role in roles)
            {
                await _roleManager.CreateAsync(new IdentityRole(role));  
                
            }
            return Ok("rollar yaradildi");
        }
    }
}
