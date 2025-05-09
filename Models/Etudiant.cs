using System.ComponentModel.DataAnnotations;

namespace TP4.Models
{
    public class Etudiant
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Numéro d'étudiant")]
        public string NumeroEtudiant { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [Display(Name = "Prénom")]
        public string Prenom { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        [Display(Name = "Nom")]
        public string Nom { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Display(Name = "Date de naissance")]
        public DateTime DateNaissance { get; set; }

        [StringLength(200)]
        [Display(Name = "Adresse")]
        public string Adresse { get; set; } = string.Empty;

        [StringLength(100)]
        [Display(Name = "Ville")]
        public string Ville { get; set; } = string.Empty;

        [StringLength(10)]
        [Display(Name = "Code postal")]
        public string CodePostal { get; set; } = string.Empty;

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

        [Display(Name = "Informations médicales")]
        public string InformationsMedicales { get; set; } = string.Empty;

        public ICollection<Inscription> Inscriptions { get; set; } = default!;
    }
}
