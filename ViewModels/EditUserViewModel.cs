using System.ComponentModel.DataAnnotations;
using TP4.Models;

namespace TP4.ViewModels
{
    public class EditUserViewModel
    {
        [Required]
        public string Id { get; set; } = default!;

        [Required]
        [EmailAddress]
        [Display(Name = "Courriel")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [Display(Name = "Prénom")]
        public string Prenom { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Nom { get; set; } = string.Empty;

        [Display(Name = "Courriel confirmé")]
        public bool EmailConfirmed { get; set; }

        [Display(Name = "Verrouillage activé")]
        public bool LockoutEnabled { get; set; }

        [Display(Name = "Date de fin de verrouillage")]
        public DateTimeOffset? LockoutEnd { get; set; }

        public List<string> SelectedRoles { get; set; } = new List<string>();

        public List<string> AllRoles { get; set; } = new List<string>();

        public int? EtudiantId { get; set; }

        public List<Etudiant> Etudiants { get; set; } = new List<Etudiant>();

        public int? EnseignantId { get; set; }

        public List<Enseignant> Enseignants { get; set; } = new List<Enseignant>();

        public bool UnlockUser { get; set; }
    }
}
