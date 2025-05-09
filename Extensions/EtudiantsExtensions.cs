using TP4.Models;

namespace TP4.Extensions
{
    public static class EtudiantsExtensions
    {
        public static string NomEtNumero(this Etudiant etudiant)
        {
            return $"{etudiant.Prenom} {etudiant.Nom} ({etudiant.NumeroEtudiant})";
        }

        public static string NomComplet(this Etudiant etudiant)
        {
            return $"{etudiant.Prenom} {etudiant.Nom}";
        }
    }
}
