using TP4.Models;

namespace TP4.ViewModels
{
    public class UserRolesViewModel
    {
        public ApplicationUser User { get; set; } = default!;
        public IList<string> UserRoles { get; set; } = default!;
        public List<string> AllRoles { get; set; } = default!;
        public List<string> SelectedRoles { get; set; } = default!;
    }
}
