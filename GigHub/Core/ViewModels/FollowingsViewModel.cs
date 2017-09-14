using GigHub.Core.Models;
using System.Collections.Generic;

namespace GigHub.Core.ViewModels
{
    public class FollowingsViewModel
    {
        public IEnumerable<ApplicationUser> MyFollowings { get; set; }
        public bool ShowActions { get; set; }
        public string Heading { get; set; }
    }
}