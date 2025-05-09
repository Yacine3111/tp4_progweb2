namespace TP4.ViewModels
{
    public class StatistiquesViewModel
    {
        public int NombreEtudiants { get; set; } = default!;
        public int NombreEnseignants { get; set; } = default!;
        public int NombreCours { get; set; } = default!;
        public int NombreInscriptions { get; set; } = default!;

        public List<MoyenneCoursViewModel> MoyennesParCours { get; set; } = default!;
        public Dictionary<string, int> EtudiantsParVille { get; set; } = default!;
    }
}
