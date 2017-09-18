using GigHub.Core.Models;
using System.Collections.Generic;

namespace GigHub.Core.Repositories
{
    public interface IFollowingRepository
    {
        Following GetFollowing(string followerId, string followeeId);
        IEnumerable<ApplicationUser> GetFollowees(string userId);
        void Create(string userId, string followeeId);
        void Delete(Following following);
    }
}