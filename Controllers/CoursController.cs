﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP4.Data;
using TP4.Models;
using TP4.ViewModels;

namespace TP4.Controllers
{
    [Authorize]
    public class CoursController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoursController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var cours = _context.Cours
                .Include(c => c.Enseignant)
                .AsQueryable();

            if (User.IsInRole(Roles.Student))
            {
                var userId = User.FindFirst(Claims.StudentId).Value;
                cours = _context.Inscriptions.Where(i => i.EtudiantId.ToString() == userId)
                     .Select(i => i.Cours);
            }

            if (User.IsInRole(Roles.Teacher) && User.FindFirst(Claims.IsCoordo) == null)
            {
                var userId = User.FindFirst(Claims.TeacherId).Value;
                cours = cours.Where(c => c.EnseignantId.ToString() == userId);
            }

            return View(await cours.ToListAsync());
        }

        [Authorize(Policy = "canSeeStudentListAndTeachers")]
        public async Task<IActionResult> ListeEtudiants(int? id)
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

            var cours = await _context.Cours
                .Include(c => c.Enseignant)
                .Include(c => c.Inscriptions)
                    .ThenInclude(i => i.Etudiant)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (cours == null)
            {
                return NotFound();
            }

            return View(cours);
        }
        [Authorize(Policy = "canEditGrades")]
        public async Task<IActionResult> SaisieParCours(int? id)
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

            var cours = await _context.Cours
                .Include(c => c.Inscriptions)
                    .ThenInclude(i => i.Etudiant)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (cours == null)
            {
                return NotFound();
            }

            var vm = new SaisieNotesViewModel()
            {
                Id = cours.Id,
                Titre = cours.Titre,
                Inscriptions = cours.Inscriptions.ToList()
            };


            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaisieParCours(int id, SaisieNotesViewModel vm)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }

            var coursExistant = await _context.Cours
                .Include(c => c.Inscriptions)
                    .ThenInclude(i => i.Etudiant)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (coursExistant == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    foreach (var inscription in vm.Inscriptions)
                    {
                        var inscriptionDb = await _context.Inscriptions.FindAsync(inscription.Id);
                        if (inscriptionDb != null)
                        {
                            inscriptionDb.NotePourcentage = inscription.NotePourcentage;

                            if (inscription.NotePourcentage.HasValue)
                            {
                                inscriptionDb.Statut = StatutInscription.Terminé;
                            }
                        }
                    }

                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("", "Une erreur s'est produite lors de la sauvegarde des notes.");
                }
            }

            vm.Inscriptions = coursExistant.Inscriptions.ToList();

            return View(vm);
        }
    }
}