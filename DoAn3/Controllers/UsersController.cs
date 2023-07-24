using DoAn3.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAn3.Controllers
{
    public class UsersController : BaseController
    {
        public UsersController(IHttpContextAccessor contextAccessor, UserManager<CustomUser> userManager, RoleManager<IdentityRole> roleManager) : base(contextAccessor, userManager, roleManager)
        {
        }

        public IActionResult Index()
        {
            var dsUser = _userManager.Users.ToList();
            return View(dsUser);
        }
        public async Task <IActionResult> ViewUpdate(string id) 
        {
            var userCanTim = await _userManager.FindByIdAsync(id);
            return PartialView(userCanTim);
        }
        [HttpPost]
        public async Task<IActionResult> doUpdate([Bind("Id,PhoneNumber,FullName,Age")] CustomUser user)
        {
           if(user != null)
            {
                var userCanUpdate = await _userManager.FindByIdAsync(user.Id);
                if(userCanUpdate != null)
                {
                    userCanUpdate.Age = user.Age;
                    userCanUpdate.FullName = user.FullName;
                    userCanUpdate.PhoneNumber = user.PhoneNumber;

                    await _userManager.UpdateAsync(userCanUpdate);
                    TempData["Thanh Cong"] = "Cap Nhat Thanh Cong!";
                    return Redirect("/Users");
                }
            }
            return BadRequest();
        }

        public async Task<IActionResult> viewSetRoles(string id)
        {
            var userDuocChon = await _userManager.FindByIdAsync(id);
            var dsAllQuyen = await _roleManager.Roles.ToListAsync();
            if(userDuocChon != null)
            {
                var userRoles = await _userManager.GetRolesAsync(userDuocChon);
                ViewBag.userRoles = userRoles.ToList();
                ViewBag.userId = id;
            }
            return View(dsAllQuyen);
        }

        [HttpPost]
        public async Task<IActionResult> doSetRole(string userid, List<string> arrRole)
        {
            var userDuocChon = await _userManager.FindByIdAsync(userid);
            var dsAllQuyen = await _roleManager.Roles.ToListAsync();
            var arrStringQuyen = dsAllQuyen.Select(r => r.Name);
            if (userDuocChon != null)
            {
                //Xoa tat ca role cua user di
                await _userManager.RemoveFromRolesAsync(userDuocChon, arrStringQuyen);
                //Them lai cac role moi
                await _userManager.AddToRolesAsync(userDuocChon, arrRole);
                TempData["ThanhCong"] = "Cap nhat quyen thanh cong!";
                return Redirect("/Users");
            }
            return BadRequest();
        }
    }
}
