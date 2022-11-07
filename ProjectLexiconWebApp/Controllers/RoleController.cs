using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectLexiconWebApp.Data;
using ProjectLexiconWebApp.Models;
using ProjectLexiconWebApp.ViewModels;

namespace ProjectLexiconWebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        readonly RoleManager<IdentityRole> _roleManager;
        readonly UserManager<ApplicationUser> _userManager;
        readonly ApplicationDbContext _context;
        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            await GetUserList();
            UserRoleViewModel model = vm;
            //foreach (var user in _userManager.Users)
            //{
            //    UserRoleViewModel.User listItem = new();
            //    listItem.UserId = user.Id;
            //    listItem.UserName = user.UserName;
            //    listItem.FirstName = user.FirstName;
            //    listItem.LastName = user.LastName;
            //    model.Users.Add(listItem);
            //}
            //for (int i = 0; i < model.Users.Count; i++)
            //{
            //    var person = await _userManager.FindByIdAsync(model.Users[i].UserId);
            //    model.Users[i].Roles.AddRange(new List<string>(await _userManager.GetRolesAsync(person)));
            //}
            //model.IdentityRoles.AddRange(_roleManager.Roles);
            return View(model);
        }

        UserRoleViewModel vm = new();
        async Task<UserRoleViewModel> GetUserList()
        {
            foreach (var user in _userManager.Users)
            {
                UserRoleViewModel.User listItem = new();
                listItem.UserId = user.Id;
                listItem.UserName = user.UserName;
                listItem.FirstName = user.FirstName;
                listItem.LastName = user.LastName;
                vm.Users.Add(listItem);
            }
            for (int i = 0; i < vm.Users.Count; i++)
            {
                var user = await _userManager.FindByIdAsync(vm.Users[i].UserId);
                vm.Users[i].Roles.AddRange(new List<string>(await _userManager.GetRolesAsync(user)));
            }
            vm.IdentityRoles.AddRange(_roleManager.Roles);
            return vm;
        }

        [HttpPost]
        public async Task<IActionResult> Search(string search)
        {
            await GetUserList();
            UserRoleViewModel model = new();
            foreach (var user in vm.Users)
            {
                if (search == null)
                {
                    return View("Index", vm);
                }
                else if (user.UserName.ToLower().Contains(search.ToLower()) || user.FirstName.ToLower().Contains(search.ToLower()) || user.LastName.ToLower().Contains(search.ToLower()) || user.Roles.Contains(search))
                {
                    model.Users.Add(user);
                }
            }
            model.IdentityRoles = vm.IdentityRoles;
            //UserRoleViewModel userList = new();
            //foreach (var user in _userManager.Users)
            //{
            //    UserRoleViewModel.User listItem = new();
            //    listItem.UserId = user.Id;
            //    listItem.UserName = user.UserName;
            //    listItem.FirstName = user.FirstName;
            //    listItem.LastName = user.LastName;
            //    model.Users.Add(listItem);
            //}
            //for (int i = 0; i < model.Users.Count; i++)
            //{
            //    var person = await _userManager.FindByIdAsync(model.Users[i].UserId);
            //    model.Users[i].Roles.AddRange(new List<string>(await _userManager.GetRolesAsync(person)));
            //}
            //model.IdentityRoles.AddRange(_roleManager.Roles);
            return View("Index", model);
        }

        public async Task<IActionResult> MakeAdmin(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.AddToRoleAsync(user, "Admin");
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> MakeUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.RemoveFromRoleAsync(user, "Admin");
            return RedirectToAction("Index");
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(string roleName)
        //{
        //    IdentityRole role = new();
        //    role.Name = roleName;
        //    role.NormalizedName = role.Name.ToUpper();
        //    await _roleManager.CreateAsync(role);

        //    return RedirectToAction("Index");
        //}

        //public async Task<IActionResult> Delete(string id)
        //{
        //    IdentityRole role = await _roleManager.FindByIdAsync(id);
        //    await _roleManager.DeleteAsync(role);
        //    return RedirectToAction("Index");
        //}
    }
}
