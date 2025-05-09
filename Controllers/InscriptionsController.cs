using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP4.Data;
using TP4.Models;

namespace TP4.Controllers
{
    public class InscriptionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InscriptionsController(ApplicationDbContext context)
        {
            _context = context;
        }

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
