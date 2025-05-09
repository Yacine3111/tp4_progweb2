using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP4.Data;
using TP4.Models;
using TP4.ViewModels;

namespace TP4.Controllers
{
    public class UsersController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ApplicationDbContext _context;

        public UsersController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            
        }

        public async Task<ActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();

            var vms = new List<UserRolesViewModel>();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var userRolesViewModel = new UserRolesViewModel()
                {
                    User = user,
                    UserRoles = roles,
                };
                vms.Add(userRolesViewModel);
            }
            
            return View(vms);
        }

        public async Task<ActionResult> Create()
        {
            var roles = _roleManager.Roles.ToList();
            var vm = new CreateUserViewModel()
            {
                AllRoles = roles.Select(r => r.Name!).ToList(),
                Enseignants = await _context.Enseignants.ToListAsync(),
                Etudiants = await _context.Etudiants.ToListAsync()
            };
            
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateUserViewModel vm)
        {

            if (vm.EtudiantId != null && !vm.SelectedRoles.Contains(Roles.Student))
            {
                ModelState.AddModelError("SelectedRoles", "Doit avoir le rôle étudiant");
            }

            if (vm.SelectedRoles.Contains(Roles.Student) && vm.EtudiantId == null)
            {
                ModelState.AddModelError("EtudiantId", "Doit avoir un étudiant assigné");
            }

            if (vm.EnseignantId != null && !vm.SelectedRoles.Contains(Roles.Teacher))
            {
                ModelState.AddModelError("SelectedRoles", "Doit avoir le rôle enseignant");
            }

            if (vm.SelectedRoles.Contains(Roles.Teacher) && vm.EnseignantId == null)
            {
                ModelState.AddModelError("EnseignantId", "Doit avoir un enseignant assigné");
            }

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = vm.Email,
                    Email = vm.Email,
                    Prenom = vm.Prenom,
                    Nom = vm.Nom,
                    EmailConfirmed = true,
                    EtudiantId = vm.EtudiantId,
                    EnseignantId = vm.EnseignantId,
                };

                var result = await _userManager.CreateAsync(user, vm.Password);
                if (result.Succeeded)
                {
                    // Attribuer les rôles sélectionnés
                    if (vm.SelectedRoles != null)
                    {
                        await _userManager.AddToRolesAsync(user, vm.SelectedRoles);
                    }

                    return RedirectToAction(nameof(Index));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            var roles = _roleManager.Roles.ToList();
            vm.AllRoles = roles.Select(r => r.Name!).ToList();
            vm.Enseignants = await _context.Enseignants.ToListAsync();
            vm.Etudiants = await _context.Etudiants.ToListAsync();

            return View(vm);
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var allRoles = await _roleManager.Roles.ToListAsync();
            var userRoles = await _userManager.GetRolesAsync(user);
            var model = new EditUserViewModel
            {
                Id = user.Id,
                Email = user.Email!,
                Prenom = user.Prenom,
                Nom = user.Nom,
                EmailConfirmed = user.EmailConfirmed,
                LockoutEnabled = user.LockoutEnabled,
                LockoutEnd = user.LockoutEnd,
                SelectedRoles = userRoles.ToList(),
                AllRoles = allRoles.Select(r => r.Name!).ToList(),
                EtudiantId = user.EtudiantId,
                EnseignantId = user.EnseignantId,
                Enseignants = await _context.Enseignants.ToListAsync(),
                Etudiants = await _context.Etudiants.ToListAsync()

            };

            return View(model);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, EditUserViewModel vm)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }

            if (vm.EtudiantId != null && !vm.SelectedRoles.Contains(Roles.Student))
            {
                ModelState.AddModelError("SelectedRoles", "Doit avoir le rôle étudiant");
            }

            if(vm.SelectedRoles.Contains(Roles.Student) && vm.EtudiantId == null)
            {
                ModelState.AddModelError("EtudiantId", "Doit avoir un étudiant assigné");
            }

            if(vm.EnseignantId != null && !vm.SelectedRoles.Contains(Roles.Teacher))
            {
                ModelState.AddModelError("SelectedRoles", "Doit avoir le rôle enseignant");
            }

            if (vm.SelectedRoles.Contains(Roles.Teacher) && vm.EnseignantId == null)
            {
                ModelState.AddModelError("EnseignantId", "Doit avoir un enseignant assigné");
            }

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                // Mise à jour des propriétés de base
                user.Prenom = vm.Prenom;
                user.Nom = vm.Nom;
                user.EmailConfirmed = vm.EmailConfirmed;
                user.LockoutEnabled = vm.LockoutEnabled;
                user.EtudiantId = vm.EtudiantId;
                user.EnseignantId = vm.EnseignantId;

                // Déverrouillage de l'utilisateur si demandé
                if (vm.UnlockUser)
                {
                    user.LockoutEnd = null;
                }

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    // Gestion des rôles
                    var currentRoles = await _userManager.GetRolesAsync(user);
                    var rolesToRemove = currentRoles.Except(vm.SelectedRoles);
                    var rolesToAdd = vm.SelectedRoles.Except(currentRoles);

                    if (rolesToRemove.Any())
                    {
                        var removeResult = await _userManager.RemoveFromRolesAsync(user, rolesToRemove);
                        if (!removeResult.Succeeded)
                        {
                            foreach (var error in removeResult.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                            }
                        }
                    }

                    if (rolesToAdd.Any())
                    {
                        var addResult = await _userManager.AddToRolesAsync(user, rolesToAdd);
                        if (!addResult.Succeeded)
                        {
                            foreach (var error in addResult.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                            }
                        }
                    }

                    return RedirectToAction(nameof(Index));
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            var allRoles = await _roleManager.Roles.ToListAsync();
            vm.AllRoles = allRoles.Select(r => r.Name!).ToList();
            vm.Enseignants = await _context.Enseignants.ToListAsync();
            vm.Etudiants = await _context.Etudiants.ToListAsync();
            return View(vm);
        }

        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
