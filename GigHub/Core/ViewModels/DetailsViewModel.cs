using GigHub.Core.Models;

namespace GigHub.Core.ViewModels
{
    public class DetailsViewModel
    {
        public Gig Gig { get; set; }
        public bool Going { get; set; }
        public bool Following { get; set; }
    }
}