using System.ComponentModel.DataAnnotations;

namespace TP4.Models
{
    public class Enseignant
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Prénom")]
        public string Prenom { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [Display(Name = "Nom")]
        public string Nom { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Display(Name = "Date d'embauche")]
        public DateTime DateEmbauche { get; set; }

        [StringLength(100)]
        [Display(Name = "Spécialité")]
        public string Specialite { get; set; } = string.Empty;

        [StringLength(200)]
        [Display(Name = "Bureau")]
        public string Bureau { get; set; } = string.Empty;

        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Téléphone")]
        public string Telephone { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Numéro d'assurance sociale")]
        [StringLength(11)]
        public string NumeroAssuranceSociale { get; set; } = string.Empty;

        [Display(Name = "Informations bancaires")]
        public string InformationsBancaires { get; set; } = string.Empty;

        public ICollection<Cours> Cours { get; set; } = default!;
    }
}
