using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TP4.Models
{
    public class Inscription
    {
        public int Id { get; set; }

        [Display(Name = "Étudiant")]
        public int EtudiantId { get; set; }

        [Display(Name = "Cours")]
        public int CoursId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date d'inscription")]
        public DateTime DateInscription { get; set; } = DateTime.Now;

        [Range(0, 100)]
        [Precision(5, 2)]
        [Display(Name = "Note finale")]
        
        public decimal? NotePourcentage { get; set; }

        [Display(Name = "Statut")]
        public StatutInscription Statut { get; set; } = StatutInscription.Inscrit;

        public Etudiant? Etudiant { get; set; }
        public Cours? Cours { get; set; }
    }
}
