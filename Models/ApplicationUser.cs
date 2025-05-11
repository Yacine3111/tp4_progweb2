using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TP4.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        [StringLength(50)]
        public string Prenom { get; set; } = string.Empty;

        [PersonalData]
        [StringLength(50)]
        public string Nom { get; set; } = string.Empty;

        public DateTime DateCreation { get; set; } = DateTime.Now;

        public int? EtudiantId { get; set; }
        public int? EnseignantId { get; set; }

        public virtual Etudiant Etudiant { get; set; } = default!;
        public virtual Enseignant Enseignant { get; set; } = default!;
    }
}
