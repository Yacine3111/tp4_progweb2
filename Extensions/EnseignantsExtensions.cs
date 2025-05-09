using TP4.Models;

namespace TP4.Extensions
{
    public static class EnseignantsExtensions
    {
        public static string NomComplet(this Enseignant enseignant)
        {
            return $"{enseignant.Prenom} {enseignant.Nom}";
        }
    }
}
