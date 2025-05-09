using System.ComponentModel.DataAnnotations;

namespace TP4.Models
{
    public class Cours
    {
        public int Id { get; set; }

        [StringLength(10)]
        [Display(Name = "Code")]
        public string Code { get; set; } = string.Empty;

        [StringLength(100)]
        [Display(Name = "Titre")]
        public string Titre { get; set; } = string.Empty;

        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        [Range(1, 10)]
        [Display(Name = "Crédits")]
        public int Credits { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date de début")]
        public DateTime DateDebut { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date de fin")]
        public DateTime DateFin { get; set; }

        [StringLength(50)]
        [Display(Name = "Local")]
        public string Local { get; set; } = string.Empty;

        [Display(Name = "Capacité maximale")]
        public int CapaciteMax { get; set; }

        [Display(Name = "Enseignant")]
        public int EnseignantId { get; set; }

        public Enseignant Enseignant { get; set; } = default!;
        public ICollection<Inscription> Inscriptions { get; set; } = default!;
    }
}
