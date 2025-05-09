using TP4.Models;

namespace TP4.ViewModels
{
    public class SaisieNotesViewModel
    {
        public int Id { get; set; } = default!;
        public string Titre { get; set; } = string.Empty;
        public List<Inscription> Inscriptions { get; set; } = new List<Inscription>();
    }
}
