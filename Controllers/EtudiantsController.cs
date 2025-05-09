using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP4.Data;

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

            if (!String.IsNullOrEmpty(searchString))
            {
                etudiants = etudiants.Where(s => s.Nom.Contains(searchString)
                                       || s.Prenom.Contains(searchString)
                                       || s.NumeroEtudiant.Contains(searchString));
            }

            return View(await etudiants.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
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

        public async Task<IActionResult> BulletinEtudiant(int? id)
        {
            if (id == null)
            {
                return NotFound();
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