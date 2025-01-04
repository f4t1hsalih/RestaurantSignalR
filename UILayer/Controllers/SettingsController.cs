using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UILayer.DTO.IdentityDTO;

namespace UILayer.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditDTO userEditDTO = new UserEditDTO
            {
                Name = value.Name,
                Surname = value.Surname,
                Username = value.UserName,
                EMail = value.Email
            };
            return View(userEditDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditDTO userEditDTO)
        {
            if (userEditDTO.Password == userEditDTO.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.Name = userEditDTO.Name;
                user.Surname = userEditDTO.Surname;
                user.UserName = userEditDTO.Username;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditDTO.Password);
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Statistik");
            }
            return View(userEditDTO);
        }
    }
}
