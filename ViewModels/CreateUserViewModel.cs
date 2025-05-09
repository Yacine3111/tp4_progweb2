using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TP4.Models;

namespace TP4.ViewModels
{
    public class CreateUserViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Courriel")]
        public string Email { get; set; } = default!;

        [Required]
        [StringLength(50)]
        [Display(Name = "Prénom")]
        public string Prenom { get; set; } = default!;

        [Required]
        [StringLength(50)]
        public string Nom { get; set; } = default!;

        [Required]
        [StringLength(100, MinimumLength = 8)]
        [DataType(DataType.Password)]
        [DisplayName("Mot de passe")]
        public string Password { get; set; } = default!;

        [DataType(DataType.Password)]
        [Display(Name = "Confirmation du mot de passe")]
        [Compare("Password", ErrorMessage = "Le mot de passe et la confirmation sont différents.")]
        public string ConfirmPassword { get; set; } = default!;

        public List<string> SelectedRoles { get; set; } = new List<string>();

        public List<string> AllRoles { get; set; } = new List<string>();

        public int? EtudiantId { get; set; }

        public List<Etudiant> Etudiants { get; set; } = new List<Etudiant>();

        public int? EnseignantId { get; set; }

        public List<Enseignant> Enseignants { get; set; } = new List<Enseignant>();
    }
}
