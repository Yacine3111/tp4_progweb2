using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP4.Data;
using TP4.Models;
using TP4.ViewModels;

namespace TP4.Controllers
{
    public class StatistiquesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StatistiquesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new StatistiquesViewModel
            {
                NombreEtudiants = await _context.Etudiants.CountAsync(),
                NombreEnseignants = await _context.Enseignants.CountAsync(),
                NombreCours = await _context.Cours.CountAsync(),
                NombreInscriptions = await _context.Inscriptions.CountAsync(),

                // Moyennes des notes par cours (pas d'anonymisation)
                MoyennesParCours = await _context.Cours
                    .Where(c => c.Inscriptions.Any(i => i.NotePourcentage.HasValue))
                    .Select(c => new MoyenneCoursViewModel
                    {
                        CoursTitre = c.Titre,
                        MoyenneNotes = c.Inscriptions
                            .Where(i => i.NotePourcentage.HasValue)
                            .Average(i => i.NotePourcentage!.Value),
                        NombreEtudiants = c.Inscriptions.Count()
                    })
                    .ToListAsync(),

                // Répartition des étudiants par ville (données personnelles non anonymisées)
                EtudiantsParVille = await _context.Etudiants
                    .GroupBy(e => e.Ville)
                    .Select(g => new { Ville = g.Key, Nombre = g.Count() })
                    .OrderByDescending(x => x.Nombre)
                    .Take(10)
                    .ToDictionaryAsync(x => x.Ville, x => x.Nombre)
            };

            return View(viewModel);
        }
    }
}