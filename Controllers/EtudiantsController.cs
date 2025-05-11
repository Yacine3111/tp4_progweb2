using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP4.Data;
using TP4.Models;

namespace TP4.Controllers
{
    [Authorize]
    public class EtudiantsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public EtudiantsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {

            var etudiants = _context.Etudiants.AsQueryable();

            if (User.IsInRole(Roles.Student))
            {
                var userId = User.FindFirst(Claims.StudentId).Value;
                etudiants = etudiants.Where(e => e.Id.ToString() == userId);

            }
            else if (User.IsInRole(Roles.Teacher) && User.FindFirst(Claims.IsCoordo) == null)
            {
                var userId = User.FindFirst(Claims.TeacherId).Value;


                etudiants = _context.Inscriptions.Where(i => i.CoursId.ToString() == userId)
                    .Select(i => i.Etudiant);
            }
            else
            {
                if (!String.IsNullOrEmpty(searchString))
                {
                    etudiants = etudiants.Where(s => s.Nom.Contains(searchString)
                                                     || s.Prenom.Contains(searchString)
                                                     || s.NumeroEtudiant.Contains(searchString));
                }
            }


            return View(await etudiants.ToListAsync());
        }
        [Authorize(Policy = "canSeeDetailsReportCard")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (User.IsInRole(Roles.Student))
            {
                var userId = User.FindFirst(Claims.StudentId).Value;

                if (userId != id.ToString())
                {
                    return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
                }
            }

            var etudiant = await _context.Etudiants
                .Include(e => e.Inscriptions)
                    .ThenInclude(i => i.Cours)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (etudiant == null)
            {
                return NotFound();
            }

            return View(etudiant);
        }

        [Authorize(Policy = "canSeeDetailsReportCard")]
        public async Task<IActionResult> BulletinEtudiant(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            if (User.IsInRole(Roles.Student))
            {
                var userId = User.FindFirst(Claims.StudentId).Value;

                if (userId != id.ToString())
                {
                    return RedirectToPage("/Account/AccessDenied", new { area = "Identity" });
                }
            }

            var etudiant = await _context.Etudiants
                .Include(e => e.Inscriptions)
                    .ThenInclude(i => i.Cours)
                        .ThenInclude(c => c.Enseignant)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (etudiant == null)
            {
                return NotFound();
            }

            return View(etudiant);
        }
    }
}