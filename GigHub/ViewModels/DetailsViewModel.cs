using GigHub.Models;

namespace GigHub.ViewModels
{
    public class DetailsViewModel
    {
        public Gig Gig { get; set; }
        public bool Going { get; set; }
        public bool Following { get; set; }
    }
}