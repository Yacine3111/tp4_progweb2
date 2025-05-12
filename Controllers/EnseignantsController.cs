using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP4.Data;
using TP4.Models;

namespace TP4.Controllers
{
    [Authorize]
    public class EnseignantsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EnseignantsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Policy = "canSeeStudentListAndTeachers")]
        public async Task<IActionResult> Index(string searchString)
        {
            var enseignants = _context.Enseignants.AsQueryable();

            if (User.IsInRole(Roles.Teacher) && User.FindFirst(Claims.IsCoordo) == null)
            {
                var userId = User.FindFirst(Claims.TeacherId).Value;
                enseignants = enseignants.Where(e => e.Id.ToString() == userId);

            }
            else
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    enseignants = enseignants.Where(s => s.Nom.Contains(searchString)
                                                         || s.Prenom.Contains(searchString)
                                                         || s.Specialite.Contains(searchString));
                }
            }

            return View(await enseignants.ToListAsync());
        }

        public async Task<IActionResult> ListeCours(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (User.IsInRole(Roles.Teacher) && User.FindFirst(Claims.IsCoordo) == null)
            {
                var userId = User.FindFirst(Claims.TeacherId).Value;

                if (userId != id.ToString())
                {
                    return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
                }
            }

            var enseignant = await _context.Enseignants
                .Include(e => e.Cours)
                    .ThenInclude(c => c.Inscriptions)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (enseignant == null)
            {
                return NotFound();
            }

            return View(enseignant);
        }
    }
}
