using DoAn3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DoAn3.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IHttpContextAccessor _contextAccessor;
        protected readonly UserManager<CustomUser> _userManager;
        protected readonly RoleManager<IdentityRole> _roleManager;
        public BaseController(IHttpContextAccessor contextAccessor,
                              UserManager<CustomUser> userManager,
                              RoleManager<IdentityRole> roleManager)
        {
            _contextAccessor = contextAccessor;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        protected async Task<CustomUser> GetCurrentUserAsync()
        {
            var currentUser = _contextAccessor.HttpContext.User;
            var ht = "";
            var userId = "";
            if (currentUser.Identity.IsAuthenticated)
            {
                ht = currentUser.Identity.Name;//Lay ra UserName
                var userTimThay = await _userManager.FindByNameAsync(currentUser.Identity.Name);
                return userTimThay;
            }
            return null;
        }
    }
}
