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
    }
}
