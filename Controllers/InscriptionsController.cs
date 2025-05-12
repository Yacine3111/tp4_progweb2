using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP4.Data;

namespace TP4.Controllers
{
    [Authorize]
    public class InscriptionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InscriptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize(Policy = "canSeeRegistration")]
        public async Task<IActionResult> Index(string searchString)
        {
            var inscriptions = _context.Inscriptions
                .Include(i => i.Etudiant)
                .Include(i => i.Cours)
                .AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                inscriptions = inscriptions.Where(i =>
                    i.Etudiant!.Nom.Contains(searchString)
                    || i.Etudiant!.Prenom.Contains(searchString)
                    || i.Etudiant!.NumeroEtudiant.Contains(searchString)
                    || i.Cours!.Titre.Contains(searchString)
                    || i.Cours!.Code.Contains(searchString)
                );
            }

            return View(await inscriptions.ToListAsync());
        }
    }
}
