using AutoMapper;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly IMapper _mapper;

        public UserController(UserManager<ApplicationUser> userManager, IMapper mapper, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        private async Task GetRolesOfUserAsync(UserVM userVM)
        {
            var user = await _userManager.FindByIdAsync(userVM.Id.ToString());
            if (user != null)
            {
                userVM.Roles = (await _userManager.GetRolesAsync(user)).ToList();
            }
        }

        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();
            var usersVM = _mapper.Map<List<UserVM>>(users);
            foreach (var userVM in usersVM)
            {
                await GetRolesOfUserAsync(userVM);
            }
            return View(usersVM);
        }

        public async Task<IActionResult> Details(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var userVM = _mapper.Map<UserVM>(user);
            await GetRolesOfUserAsync(userVM);
            return View(userVM);
        }

        [Authorize(Roles = "BlogOwner")]
        public IActionResult Create()
        {
            ViewBag.Roles = _roleManager.Roles;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserVM userVM, List<string> Roles)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<ApplicationUser>(userVM);
                var result = await _userManager.CreateAsync(user, userVM.Password);
                if (result.Succeeded)
                {
                    if (Roles != null)
                    {
                        foreach (var role in Roles)
                        {
                            await _userManager.AddToRoleAsync(user, role);
                        }
                    }
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            ViewBag.Roles = _roleManager.Roles;
            return View(userVM);
        }

        [Authorize(Roles = "BlogOwner")]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var userVM = _mapper.Map<UserVM>(user);
            await GetRolesOfUserAsync(userVM);
            ViewBag.Roles = _roleManager.Roles;
            return View(userVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserVM userVM, List<string> Roles)
        {
            // Remove the validation from the Password field
            ModelState.Remove("Password");

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(userVM.Id.ToString());
                if (user == null)
                {
                    return NotFound();
                }
                _mapper.Map(userVM, user);

                if (!string.IsNullOrEmpty(userVM.Password))
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var resetPasswordResult = await _userManager.ResetPasswordAsync(user, token, userVM.Password);
                    if (!resetPasswordResult.Succeeded)
                    {
                        foreach (var error in resetPasswordResult.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        ViewBag.Roles = _roleManager.Roles;
                        return View(userVM);
                    }
                }

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    if (Roles != null)
                    {
                        foreach (var role in Roles)
                        {
                            if (!userRoles.Contains(role))
                            {
                                await _userManager.AddToRoleAsync(user, role);
                            }
                        }
                    }
                    foreach (var role in userRoles)
                    {
                        if (!Roles.Contains(role))
                        {
                            await _userManager.RemoveFromRoleAsync(user, role);
                        }
                    }
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            ViewBag.Roles = _roleManager.Roles;
            return View(userVM);
        }

        [Authorize(Roles = "BlogOwner")]
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return Json(new { status = true });
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return Json(new { status = false });
        }
    }
}
