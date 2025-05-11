using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using TP4.Models;

namespace TP4.Data
{
    public static class RolesInitializer
    {
        public static async Task InitializeAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (userManager == null || roleManager == null)
            {
                return;
            }

            string[] roleNames = {
                Roles.Admin,
                Roles.Staff,
                Roles.Teacher,
                Roles.Student,
            };

            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var adminUser = await CreateUser(userManager, "admin@admin.com", "Admin", "Admin123!");
            await AddRole(userManager, adminUser, Roles.Admin);

            var staffUser = await CreateUser(userManager, "staff@staff.com", "Personnel", "Staff123!");
            await AddRole(userManager, staffUser, Roles.Staff);

            var coordoUser = await CreateUser(userManager, "coordo@coordo.com", "Coordo", "Coordo123!", enseignantId: 2);
            await AddRole(userManager, coordoUser, Roles.Teacher);

            var coordoClaims = new List<Claim>
            {
                new Claim(Claims.IsCoordo, "true")
            };

            await AddClaims(userManager, coordoUser, coordoClaims.ToArray());


            var teacherUser = await CreateUser(userManager, "teacher@teacher.com", "Enseignant", "Teacher123!", enseignantId: 1);
            await AddRole(userManager, teacherUser, Roles.Teacher);

            var teacherClaims = new List<Claim>
            {
                new Claim(Claims.TeacherId, teacherUser.EnseignantId.ToString())
            };

            await AddClaims(userManager, teacherUser, teacherClaims.ToArray());

            var studentUser = await CreateUser(userManager, "student@student.com", "Étudiant", "Student123!", etudiantId: 1);
            await AddRole(userManager, studentUser, Roles.Student);

            var studentClaims = new List<Claim>
            {
                new Claim(Claims.StudentId, studentUser.EtudiantId.ToString())
            };

            await AddClaims(userManager, studentUser, studentClaims.ToArray());
        }

        private static async Task<ApplicationUser> CreateUser(UserManager<ApplicationUser> userManager, string email, string firstName, string password, int? enseignantId = null, int? etudiantId = null)
        {
            var user = await userManager.FindByEmailAsync(email);

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    Prenom = firstName,
                    Nom = "",
                    EmailConfirmed = true,
                    EtudiantId = etudiantId,
                    EnseignantId = enseignantId
                };

                await userManager.CreateAsync(user, password);
            }

            return user;
        }

        private static async Task AddRole(UserManager<ApplicationUser> userManager, ApplicationUser user, string role)
        {
            var roles = await userManager.GetRolesAsync(user);
            if (!roles.Contains(role))
            {
                await userManager.AddToRoleAsync(user, role);
            }
        }

        public static async Task AddClaims(UserManager<ApplicationUser> userManager, ApplicationUser user, params Claim[] claims)
        {
            var existingClaims = await userManager.GetClaimsAsync(user);
            foreach (var claim in claims)
            {
                if (!existingClaims.Any(c => c.Type == claim.Type && c.Value == claim.Value))
                {
                    await userManager.AddClaimAsync(user, claim);
                }
            }
        }
    }

}
